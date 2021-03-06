using Mutagen.Bethesda.Plugins.Allocators;
using System;
using Noggog;
using System.Collections.Generic;
using System.Diagnostics;
using Loqui;
using Mutagen.Bethesda.Plugins.Binary;

namespace Mutagen.Bethesda.Plugins.Records
{
    /// <summary> 
    /// An abstract base class for Mods to inherit from for some common functionality 
    /// </summary> 
    [DebuggerDisplay("{GameRelease} {ModKey.ToString()}")]
    public abstract class AMod : IMod
    {
        /// <inheritdoc />
        public ModKey ModKey { get; }

        /// <inheritdoc />
        public abstract GameRelease GameRelease { get; }

        private IFormKeyAllocator _allocator;

        protected AMod()
        {
            this.ModKey = ModKey.Null;
            this._allocator = new SimpleFormKeyAllocator(this);
        }

        /// <summary> 
        /// Constructor 
        /// </summary> 
        /// <param name="modKey">Key to assign the mod</param> 
        public AMod(ModKey modKey)
        {
            this.ModKey = modKey;
            this._allocator = new SimpleFormKeyAllocator(this);
        }

        #region NonImplemented IMod 
        IEnumerable<IFormLinkGetter> IFormLinkContainerGetter.ContainedFormLinks => throw new NotImplementedException();
        void IFormLinkContainer.RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => throw new NotImplementedException();
        IReadOnlyList<IMasterReferenceGetter> IModGetter.MasterReferences => throw new NotImplementedException();
        IList<MasterReference> IMod.MasterReferences => throw new NotImplementedException();
        uint IMod.NextFormID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        uint IModGetter.NextFormID { get => throw new NotImplementedException(); }
        public abstract bool CanUseLocalization { get; }
        public abstract bool UsingLocalization { get; set; }
        bool IModGetter.UsingLocalization => throw new NotImplementedException();
        ICache<T, FormKey> IMod.GetGroup<T>() => throw new NotImplementedException();
        public abstract void SyncRecordCount();
        IReadOnlyCache<T, FormKey> IModGetter.GetTopLevelGroupGetter<T>() => throw new NotImplementedException();
        void IModGetter.WriteToBinary(string path, BinaryWriteParameters? param) => throw new NotImplementedException();
        void IModGetter.WriteToBinaryParallel(string path, BinaryWriteParameters? param) => throw new NotImplementedException();
        IEnumerable<T> IMajorRecordEnumerable.EnumerateMajorRecords<T>(bool throwIfUnknown) => throw new NotImplementedException();
        IEnumerable<IMajorRecordCommonGetter> IMajorRecordGetterEnumerable.EnumerateMajorRecords() => throw new NotImplementedException();
        IEnumerable<T> IMajorRecordGetterEnumerable.EnumerateMajorRecords<T>(bool throwIfUnknown) => throw new NotImplementedException();
        IEnumerable<IMajorRecordCommonGetter> IMajorRecordGetterEnumerable.EnumerateMajorRecords(Type type, bool throwIfUnknown) => throw new NotImplementedException();
        IEnumerable<IMajorRecordCommon> IMajorRecordEnumerable.EnumerateMajorRecords() => throw new NotImplementedException();
        IEnumerable<IMajorRecordCommon> IMajorRecordEnumerable.EnumerateMajorRecords(Type? t, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(FormKey formKey) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(IEnumerable<FormKey> formKeys) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(HashSet<FormKey> formKeys) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(FormKey formKey, Type type, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(IEnumerable<FormKey> formKeys, Type type, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove(HashSet<FormKey> formKeys, Type type, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove<TMajor>(FormKey formKey, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove<TMajor>(HashSet<FormKey> formKeys, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove<TMajor>(IEnumerable<FormKey> formKeys, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove<TMajor>(TMajor record, bool throwIfUnknown) => throw new NotImplementedException();
        void IMajorRecordEnumerable.Remove<TMajor>(IEnumerable<TMajor> records, bool throwIfUnknown) => throw new NotImplementedException();
        public IMask<bool> GetEqualsMask(object rhs, EqualsMaskHelper.Include include = EqualsMaskHelper.Include.OnlyFailures) => throw new NotImplementedException();
        #endregion

        /// <inheritdoc />
        public FormKey GetNextFormKey()
        {
            return _allocator.GetNextFormKey();
        }

        /// <inheritdoc />
        public FormKey GetNextFormKey(string? editorID)
        {
            if (editorID == null) return GetNextFormKey();
            return _allocator.GetNextFormKey(editorID);
        }

        /// <inheritdoc />
        public TAlloc SetAllocator<TAlloc>(TAlloc allocator)
            where TAlloc : IFormKeyAllocator
        {
            _allocator = allocator;
            return allocator;
        }
    }
}
