using System;
using System.Linq;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class Effect
    {
        public enum EffectType
        {
            Self = 0,
            Touch = 1,
            Target = 2
        }
    }

    namespace Internals
    {
        public partial class EffectBinaryCreateTranslation
        {
            public static partial void FillBinaryEffectInitialCustom(MutagenFrame frame, IEffect item)
            {
                var subMeta = frame.ReadSubrecord();
                if (subMeta.ContentLength != Plugins.Internals.Constants.HeaderLength)
                {
                    throw new ArgumentException($"Magic effect name must be length 4.  Was: {subMeta.ContentLength}");
                }
                var magicEffName = frame.ReadMemory(4);

                if (!frame.Reader.TryGetSubrecord(RecordTypes.EFIT, out var efitMeta))
                {
                    throw new ArgumentException("Expected EFIT header.");
                }
                if (efitMeta.ContentLength < Plugins.Internals.Constants.HeaderLength)
                {
                    throw new ArgumentException($"Magic effect ref length was less than 4.  Was: {efitMeta.ContentLength}");
                }
                var magicEffName2 = frame.GetMemory(amount: Plugins.Internals.Constants.HeaderLength, offset: efitMeta.HeaderLength);
                if (!magicEffName.Span.SequenceEqual(magicEffName2.Span))
                {
                    throw new ArgumentException($"Magic effect names did not match. {BinaryStringUtility.ToZString(magicEffName)} != {BinaryStringUtility.ToZString(magicEffName2)}");
                }
            }
        }

        public partial class EffectBinaryWriteTranslation
        {
            public static partial void WriteBinaryEffectInitialCustom(MutagenWriter writer, IEffectGetter item)
            {
                using (HeaderExport.Subrecord(writer, RecordTypes.EFID))
                {
                    RecordTypeBinaryTranslation.Instance.Write(
                        writer: writer,
                        item: item.Data.MagicEffect);
                }
            }
        }
    }
}
