﻿using Alphaleonis.Win32.Filesystem;
using DynamicData;
using DynamicData.Binding;
using Noggog.WPF;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mutagen.Bethesda.Tests.GUI
{
    public class PassthroughTestVM : ViewModel
    {
        public GroupTestVM Group { get; }
        public PassthroughVM Settings { get; }

        public SourceList<TestVM> Tests = new SourceList<TestVM>();
        private readonly IObservableCollection<TestVM> _testsDisplay;
        public IObservableCollection<TestVM> TestsDisplay => _testsDisplay;

        private readonly ObservableAsPropertyHelper<string> _Name;
        public string Name => _Name.Value;

        public ReactiveCommand<Unit, Unit> SelectCommand { get; }

        private readonly ObservableAsPropertyHelper<bool> _IsSelected;
        public bool IsSelected => _IsSelected.Value;

        [Reactive]
        public TestVM? SelectedTest { get; set; }

        private readonly ObservableAsPropertyHelper<TestState> _State;
        public TestState State => _State.Value;

        [Reactive]
        public TimeSpan? TimeSpent { get; private set; }

        public PassthroughTestVM(GroupTestVM group, PassthroughVM p)
        {
            Group = group;
            Settings = p;
            _Name = this.WhenAny(x => x.Settings.Path.TargetPath)
                .Select(path =>
                {
                    try
                    {
                        return Path.GetFileName(path);
                    }
                    catch (Exception)
                    {
                        return path;
                    }
                })
                .ToGuiProperty<string>(this, nameof(Name));
            Tests.Connect()
                .Bind(out _testsDisplay)
                .Subscribe()
                .DisposeWith(this);

            SelectCommand = ReactiveCommand.Create(() =>
            {
                Group.Parent.SelectedPassthrough = this;
            });
            _IsSelected = Group.Parent.WhenAny(x => x.SelectedPassthrough)
                .Select(x => x == this)
                .ToGuiProperty(this, nameof(IsSelected));
            _State = Tests.Connect()
                .AutoRefresh(x => x.State)
                .Transform(p => p.State, transformOnRefresh: true)
                .QueryWhenChanged(states =>
                {
                    bool notComplete = false;
                    foreach (var state in states)
                    {
                        if (state == TestState.Error) return TestState.Error;
                        if (state != TestState.Complete)
                        {
                            notComplete = true;
                        }
                    }
                    return notComplete ? TestState.Running : TestState.Complete;
                })
                .ToGuiProperty(this, nameof(State));
        }

        public async Task Run()
        {
            var passthrough = PassthroughTest.Factory(new PassthroughTestParams()
            {
                NicknameSuffix = Settings.Parent.NicknameSuffix,
                PassthroughSettings = Settings.Parent.Parent.GetPassthroughSettings(),
                Target = new Target()
                {
                    Do = true,
                    Path = Settings.Path.TargetPath
                },
                GameRelease = Settings.Parent.GameRelease,
            });
            var topTest = passthrough.BinaryPassthroughTest();
            AddTest(topTest, parent: null);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await topTest.Start();
            sw.Stop();
            TimeSpent = sw.Elapsed;
        }

        private void AddTest(Test test, TestVM? parent)
        {
            var vm = new TestVM(this, test, parent);
            Tests.Add(vm);
            foreach (var child in test.Children)
            {
                AddTest(child, vm);
            }
        }
    }
}