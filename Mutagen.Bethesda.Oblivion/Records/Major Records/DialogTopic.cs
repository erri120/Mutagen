﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Oblivion.Internals;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class DialogTopic
    {
        partial void PostDuplicate(DialogTopic obj, DialogTopic rhs, Func<FormKey> getNextFormKey, IList<(IMajorRecordCommon Record, FormKey OriginalFormKey)> duplicatedRecords)
        {
            obj.Items.SetTo(rhs.Items.Select((dia) => (DialogItem)dia.Duplicate(getNextFormKey, duplicatedRecords)));
        }
    }

    namespace Internals
    {
        public partial class DialogTopicBinaryTranslation
        {
            static partial void CustomBinaryEnd_Import(MutagenFrame frame, DialogTopic obj, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (frame.Reader.Complete) return;
                var next = HeaderTranslation.GetNextType(
                    reader: frame.Reader,
                    contentLength: out var len,
                    finalPos: out var _,
                    hopGroup: false);
                if (!next.Equals(Group_Registration.GRUP_HEADER)) return;
                frame.Reader.Position += 8;
                var formKey = FormKey.Factory(masterReferences, frame.Reader.ReadUInt32());
                var grupType = (GroupTypeEnum)frame.Reader.ReadInt32();
                if (grupType == GroupTypeEnum.TopicChildren)
                {
                    obj.Timestamp = frame.Reader.ReadBytes(4);
                    if (formKey != obj.FormKey)
                    {
                        throw new ArgumentException("Dialog children group did not match the FormID of the parent.");
                    }
                }
                else
                {
                    frame.Reader.Position -= 16;
                    return;
                }
                Mutagen.Bethesda.Binary.ListBinaryTranslation<DialogItem>.Instance.ParseRepeatedItem(
                    frame: frame.SpawnWithLength(len - Mutagen.Bethesda.Constants.RECORD_HEADER_LENGTH),
                    fieldIndex: (int)DialogTopic_FieldIndex.Items,
                    lengthLength: 4,
                    item: obj.Items,
                    errorMask: errorMask,
                    transl: (MutagenFrame r, RecordType header, out DialogItem listItem, ErrorMaskBuilder listErrorMask) =>
                    {
                        return LoquiBinaryTranslation<DialogItem>.Instance.Parse(
                            frame: r,
                            item: out listItem,
                            masterReferences: masterReferences,
                            errorMask: listErrorMask);
                    }
                    );
            }

            static partial void CustomBinaryEnd_Export(MutagenWriter writer, IDialogTopicInternalGetter obj, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (obj.Items.Count == 0) return;
                using (HeaderExport.ExportHeader(writer, Group_Registration.GRUP_HEADER, ObjectType.Group))
                {
                    FormKeyBinaryTranslation.Instance.Write(
                        writer,
                        obj.FormKey,
                        masterReferences);
                    writer.Write((int)GroupTypeEnum.TopicChildren);
                    writer.Write(obj.Timestamp);
                    Mutagen.Bethesda.Binary.ListBinaryTranslation<IDialogItemInternalGetter>.Instance.Write(
                        writer: writer,
                        items: obj.Items,
                        fieldIndex: (int)DialogTopic_FieldIndex.Items,
                        errorMask: errorMask,
                        transl: (MutagenWriter subWriter, IDialogItemInternalGetter subItem, ErrorMaskBuilder listErrMask) =>
                        {
                           subItem.Write_Binary(
                                writer: subWriter,
                                masterReferences: masterReferences,
                                errorMask: listErrMask);
                        });
                }
            }
        }
    }
}
