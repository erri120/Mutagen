﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Binary
{
    public class HeaderTranslation
    {
        public static bool TryParse(
            BinaryReader reader,
            RecordType expectedHeader,
            out long contentLength,
            int lengthLength = 4)
        {
            var header = reader.ReadChars(4);
            if (!expectedHeader.Equals(header))
            {
                contentLength = 0;
                return false;
            }
            switch (lengthLength)
            {
                case 1:
                    contentLength = reader.ReadByte();
                    break;
                case 2:
                    contentLength = reader.ReadUInt16();
                    break;
                case 4:
                    contentLength = reader.ReadUInt32();
                    break;
                case 8:
                    contentLength = reader.ReadInt64();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return true;
        }

        public static long Parse(
            BinaryReader reader,
            RecordType expectedHeader,
            int lengthLength = 4)
        {
            if (!TryParse(
                reader,
                expectedHeader,
                out var contentLength,
                lengthLength))
            {
                throw new ArgumentException($"Expected header was not read in: {expectedHeader}");
            }
            return contentLength;
        }

        public static RecordType GetNextRecordType(
            BinaryReader reader,
            out long contentLength,
            int lengthLength = 4)
        {
            var header = reader.ReadChars(4);
            switch (lengthLength)
            {
                case 1:
                    contentLength = reader.ReadByte();
                    break;
                case 2:
                    contentLength = reader.ReadUInt16();
                    break;
                case 4:
                    contentLength = reader.ReadUInt32();
                    break;
                case 8:
                    contentLength = reader.ReadInt64();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return new RecordType(new string(header));
        }
    }
}
