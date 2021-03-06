using DynamicData;
using Noggog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace Mutagen.Bethesda.Plugins.Order
{
    public static class CreationClubListings
    {
        public static FilePath? GetListingsPath(GameCategory category, DirectoryPath dataPath)
        {
            switch (category)
            {
                case GameCategory.Oblivion:
                    return null;
                case GameCategory.Skyrim:
                case GameCategory.Fallout4:
                    return Path.Combine(Path.GetDirectoryName(dataPath.Path)!, $"{category}.ccc");
                default:
                    throw new NotImplementedException();
            }
        }

        public static IEnumerable<IModListingGetter> GetListings(GameCategory category, DirectoryPath dataPath)
        {
            var path = GetListingsPath(category, dataPath);
            if (path == null || !path.Value.Exists) return Enumerable.Empty<IModListingGetter>();
            return ListingsFromPath(
                path.Value,
                dataPath);
        }

        public static IEnumerable<IModListingGetter> ListingsFromPath(
            FilePath cccFilePath,
            DirectoryPath dataPath)
        {
            return File.ReadAllLines(cccFilePath.Path)
                .Select(x => ModKey.FromNameAndExtension(x))
                .Where(x => File.Exists(Path.Combine(dataPath.Path, x.FileName)))
                .Select(x => new ModListing(x, enabled: true))
                .ToList();
        }

        public static IObservable<IChangeSet<IModListingGetter>> GetLiveLoadOrder(
            FilePath cccFilePath,
            DirectoryPath dataFolderPath,
            out IObservable<ErrorResponse> state,
            bool orderListings = true)
        {
            var raw = ObservableExt.WatchFile(cccFilePath.Path)
                .StartWith(Unit.Default)
                .Select(_ =>
                {
                    try
                    {
                        return GetResponse<IObservable<IChangeSet<ModKey>>>.Succeed(
                            File.ReadAllLines(cccFilePath.Path)
                                .Select(x => ModKey.FromNameAndExtension(x))
                                .AsObservableChangeSet());
                    }
                    catch (Exception ex)
                    {
                        return GetResponse<IObservable<IChangeSet<ModKey>>>.Fail(ex);
                    }
                })
                .Replay(1)
                .RefCount();
            state = raw
                .Select(r => (ErrorResponse)r);
            var ret = ObservableListEx.And(
                raw
                .Select(r =>
                {
                    return r.Value ?? Observable.Empty<IChangeSet<ModKey>>();
                })
                .Switch(),
                ObservableExt.WatchFolderContents(dataFolderPath.Path)
                    .Transform(x =>
                    {
                        if (ModKey.TryFromNameAndExtension(Path.GetFileName(x), out var modKey))
                        {
                            return TryGet<ModKey>.Succeed(modKey);
                        }
                        return TryGet<ModKey>.Failure;
                    })
                    .Filter(x => x.Succeeded)
                    .Transform(x => x.Value)
                    .RemoveKey())
                .Transform<ModKey, IModListingGetter>(x => new ModListing(x, true));
            if (orderListings)
            {
                ret = ret.OrderListings();
            }
            return ret;
        }

        public static IObservable<Unit> GetLoadOrderChanged(
            FilePath cccFilePath,
            DirectoryPath dataFolderPath)
        {
            return GetLiveLoadOrder(cccFilePath, dataFolderPath, out _, orderListings: false)
                .QueryWhenChanged(q => Unit.Default);
        }
    }
}
