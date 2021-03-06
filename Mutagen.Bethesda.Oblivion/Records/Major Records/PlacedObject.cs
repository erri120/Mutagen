using System;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class PlacedObject
    {
        [Flags]
        public enum ActionFlag
        {
            UseDefault = 0x001,
            Activate = 0x002,
            Open = 0x004,
            OpenByDefault = 0x008
        }
    }

    namespace Internals
    {
        public partial class PlacedObjectBinaryCreateTranslation
        {
            public static partial void FillBinaryOpenByDefaultCustom(MutagenFrame frame, IPlacedObjectInternal item)
            {
                item.OpenByDefault = true;
                frame.Position += frame.MetaData.Constants.SubConstants.HeaderLength;
            }
        }

        public partial class PlacedObjectBinaryWriteTranslation
        {
            public static partial void WriteBinaryOpenByDefaultCustom(MutagenWriter writer, IPlacedObjectGetter item)
            {
                if (item.OpenByDefault)
                {
                    using (HeaderExport.Subrecord(writer, RecordTypes.ONAM))
                    {
                    }
                }
            }
        }

        public partial class PlacedObjectBinaryOverlay
        {
            private int? _OpenByDefaultLocation;
            public bool GetOpenByDefaultCustom() => _OpenByDefaultLocation.HasValue;
            partial void OpenByDefaultCustomParse(OverlayStream stream, long finalPos, int offset)
            {
                _OpenByDefaultLocation = (ushort)(stream.Position - offset);
            }
        }
    }
}
