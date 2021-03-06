using Loqui;
using Loqui.Generation;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.IO;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Generation.Modules.Plugin
{
    public class GameCategoryExtensionsModule : GenerationModule
    {
        public override async Task FinalizeGeneration(ProtocolGeneration proto)
        {
            await base.FinalizeGeneration(proto);
            if (proto.Protocol.Namespace != "Bethesda") return;

            FileGeneration fg = new FileGeneration();
            fg.AppendLine("using System;");
            fg.AppendLine("using Mutagen.Bethesda.Plugins.Records;");
            fg.AppendLine();

            using (new NamespaceWrapper(fg, "Mutagen.Bethesda"))
            {
                using (var cl = new ClassWrapper(fg, "GameCategoryHelper"))
                {
                    cl.Partial = true;
                    cl.Static = true;
                }
                using (new BraceWrapper(fg))
                {
                    using (var args = new FunctionWrapper(fg,
                        $"public static {nameof(GameCategory)} FromModType<TMod>"))
                    {
                        args.Wheres.Add($"where TMod : {nameof(IModGetter)}");
                    }
                    using (new BraceWrapper(fg))
                    {
                        fg.AppendLine("return TryFromModType<TMod>() ?? throw new ArgumentException($\"Unknown game type for: {typeof(TMod).Name}\");");
                    }
                    fg.AppendLine();
                    
                    using (var args = new FunctionWrapper(fg,
                        $"public static {nameof(GameCategory)}? TryFromModType<TMod>"))
                    {
                        args.Wheres.Add($"where TMod : {nameof(IModGetter)}");
                    }
                    using (new BraceWrapper(fg))
                    {
                        fg.AppendLine("switch (typeof(TMod).Name)");
                        using (new BraceWrapper(fg))
                        {
                            foreach (var cat in EnumExt.GetValues<GameCategory>())
                            {
                                fg.AppendLine($"case \"I{cat}Mod\":");
                                fg.AppendLine($"case \"I{cat}ModGetter\":");
                                using (new DepthWrapper(fg))
                                {
                                    fg.AppendLine($"return {nameof(GameCategory)}.{cat};");
                                }
                            }

                            fg.AppendLine("default:");
                            using (new BraceWrapper(fg))
                            {
                                fg.AppendLine("return null;");
                            }
                        }
                    }
                }
            }

            var path = Path.Combine(proto.DefFileLocation.FullName, "../Extensions", $"GameCategoryHelper{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
            fg.Generate(path);
            proto.GeneratedFiles.Add(path, ProjItemType.Compile);
        }
    }
}
