/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Skyrim.Internals;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public abstract partial class GameSetting :
        SkyrimMajorRecord,
        IGameSettingInternal,
        ILoquiObjectSetter<GameSetting>,
        IEquatable<IGameSettingGetter>
    {
        #region Ctor
        protected GameSetting()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            GameSettingMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IGameSettingGetter rhs)) return false;
            return ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IGameSettingGetter? obj)
        {
            return ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            SkyrimMajorRecord.Mask<TItem>,
            IMask<TItem>,
            IEquatable<Mask<TItem>>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
            }

            public Mask(
                TItem MajorRecordFlagsRaw,
                TItem FormKey,
                TItem VersionControl,
                TItem EditorID,
                TItem FormVersion,
                TItem Version2)
            : base(
                MajorRecordFlagsRaw: MajorRecordFlagsRaw,
                FormKey: FormKey,
                VersionControl: VersionControl,
                EditorID: EditorID,
                FormVersion: FormVersion,
                Version2: Version2)
            {
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!base.Equals(rhs)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new GameSetting.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(GameSetting.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, GameSetting.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(GameSetting.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            SkyrimMajorRecord.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
                switch (enu)
                {
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var fg = new FileGeneration();
                ToString(fg, null);
                return fg.ToString();
            }

            public override void ToString(FileGeneration fg, string? name = null)
            {
                fg.AppendLine($"{(name ?? "ErrorMask")} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (this.Overall != null)
                    {
                        fg.AppendLine("Overall =>");
                        fg.AppendLine("[");
                        using (new DepthWrapper(fg))
                        {
                            fg.AppendLine($"{this.Overall}");
                        }
                        fg.AppendLine("]");
                    }
                    ToString_FillInternal(fg);
                }
                fg.AppendLine("]");
            }
            protected override void ToString_FillInternal(FileGeneration fg)
            {
                base.ToString_FillInternal(fg);
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            SkyrimMajorRecord.TranslationMask,
            ITranslationMask
        {
            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
            }

            #endregion

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public static readonly RecordType GrupRecordType = GameSetting_Registration.TriggeringRecordType;
        public GameSetting(FormKey formKey)
        {
            this.FormKey = formKey;
            CustomCtor();
        }

        public GameSetting(IMod mod)
            : this(mod.GetNextFormKey())
        {
        }

        public GameSetting(IMod mod, string editorID)
            : this(mod.GetNextFormKey(editorID))
        {
            this.EditorID = editorID;
        }

        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => GameSettingBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((GameSettingBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((GameSettingSetterCommon)((IGameSettingGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new GameSetting GetNew()
        {
            throw new ArgumentException("New called on an abstract class.");
        }

    }
    #endregion

    #region Interface
    public partial interface IGameSetting :
        IGameSettingGetter,
        ISkyrimMajorRecord,
        ILoquiObjectSetter<IGameSettingInternal>
    {
    }

    public partial interface IGameSettingInternal :
        ISkyrimMajorRecordInternal,
        IGameSetting,
        IGameSettingGetter
    {
    }

    public partial interface IGameSettingGetter :
        ISkyrimMajorRecordGetter,
        ILoquiObject<IGameSettingGetter>,
        IBinaryItem
    {
        static new ILoquiRegistration Registration => GameSetting_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class GameSettingMixIn
    {
        public static void Clear(this IGameSettingInternal item)
        {
            ((GameSettingSetterCommon)((IGameSettingGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static GameSetting.Mask<bool> GetEqualsMask(
            this IGameSettingGetter item,
            IGameSettingGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IGameSettingGetter item,
            string? name = null,
            GameSetting.Mask<bool>? printMask = null)
        {
            return ((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IGameSettingGetter item,
            FileGeneration fg,
            string? name = null,
            GameSetting.Mask<bool>? printMask = null)
        {
            ((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IGameSettingGetter item,
            IGameSettingGetter rhs)
        {
            return ((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs);
        }

        public static void DeepCopyIn(
            this IGameSettingInternal lhs,
            IGameSettingGetter rhs,
            out GameSetting.ErrorMask errorMask,
            GameSetting.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((GameSettingSetterTranslationCommon)((IGameSettingGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = GameSetting.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IGameSettingInternal lhs,
            IGameSettingGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((GameSettingSetterTranslationCommon)((IGameSettingGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static GameSetting DeepCopy(
            this IGameSettingGetter item,
            GameSetting.TranslationMask? copyMask = null)
        {
            return ((GameSettingSetterTranslationCommon)((IGameSettingGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static GameSetting DeepCopy(
            this IGameSettingGetter item,
            out GameSetting.ErrorMask errorMask,
            GameSetting.TranslationMask? copyMask = null)
        {
            return ((GameSettingSetterTranslationCommon)((IGameSettingGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static GameSetting DeepCopy(
            this IGameSettingGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((GameSettingSetterTranslationCommon)((IGameSettingGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IGameSettingInternal item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((GameSettingSetterCommon)((IGameSettingGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum GameSetting_FieldIndex
    {
        MajorRecordFlagsRaw = 0,
        FormKey = 1,
        VersionControl = 2,
        EditorID = 3,
        FormVersion = 4,
        Version2 = 5,
    }
    #endregion

    #region Registration
    public partial class GameSetting_Registration : ILoquiRegistration
    {
        public static readonly GameSetting_Registration Instance = new GameSetting_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 5,
            version: 0);

        public const string GUID = "f850894f-494c-4527-8a48-1209ae13f043";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 6;

        public static readonly Type MaskType = typeof(GameSetting.Mask<>);

        public static readonly Type ErrorMaskType = typeof(GameSetting.ErrorMask);

        public static readonly Type ClassType = typeof(GameSetting);

        public static readonly Type GetterType = typeof(IGameSettingGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IGameSetting);

        public static readonly Type? InternalSetterType = typeof(IGameSettingInternal);

        public const string FullName = "Mutagen.Bethesda.Skyrim.GameSetting";

        public const string Name = "GameSetting";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly RecordType TriggeringRecordType = RecordTypes.GMST;
        public static readonly Type BinaryWriteTranslation = typeof(GameSettingBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    public partial class GameSettingSetterCommon : SkyrimMajorRecordSetterCommon
    {
        public new static readonly GameSettingSetterCommon Instance = new GameSettingSetterCommon();

        partial void ClearPartial();
        
        public virtual void Clear(IGameSettingInternal item)
        {
            ClearPartial();
            base.Clear(item);
        }
        
        public override void Clear(ISkyrimMajorRecordInternal item)
        {
            Clear(item: (IGameSettingInternal)item);
        }
        
        public override void Clear(IMajorRecordInternal item)
        {
            Clear(item: (IGameSettingInternal)item);
        }
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IGameSettingInternal item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
        }
        
        public override void CopyInFromBinary(
            ISkyrimMajorRecordInternal item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (GameSetting)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        public override void CopyInFromBinary(
            IMajorRecordInternal item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (GameSetting)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class GameSettingCommon : SkyrimMajorRecordCommon
    {
        public new static readonly GameSettingCommon Instance = new GameSettingCommon();

        public GameSetting.Mask<bool> GetEqualsMask(
            IGameSettingGetter item,
            IGameSettingGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new GameSetting.Mask<bool>(false);
            ((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IGameSettingGetter item,
            IGameSettingGetter rhs,
            GameSetting.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            IGameSettingGetter item,
            string? name = null,
            GameSetting.Mask<bool>? printMask = null)
        {
            var fg = new FileGeneration();
            ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
            return fg.ToString();
        }
        
        public void ToString(
            IGameSettingGetter item,
            FileGeneration fg,
            string? name = null,
            GameSetting.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"GameSetting =>");
            }
            else
            {
                fg.AppendLine($"{name} (GameSetting) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                ToStringFields(
                    item: item,
                    fg: fg,
                    printMask: printMask);
            }
            fg.AppendLine("]");
        }
        
        protected static void ToStringFields(
            IGameSettingGetter item,
            FileGeneration fg,
            GameSetting.Mask<bool>? printMask = null)
        {
            SkyrimMajorRecordCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
        }
        
        public static GameSetting_FieldIndex ConvertFieldIndex(SkyrimMajorRecord_FieldIndex index)
        {
            switch (index)
            {
                case SkyrimMajorRecord_FieldIndex.MajorRecordFlagsRaw:
                    return (GameSetting_FieldIndex)((int)index);
                case SkyrimMajorRecord_FieldIndex.FormKey:
                    return (GameSetting_FieldIndex)((int)index);
                case SkyrimMajorRecord_FieldIndex.VersionControl:
                    return (GameSetting_FieldIndex)((int)index);
                case SkyrimMajorRecord_FieldIndex.EditorID:
                    return (GameSetting_FieldIndex)((int)index);
                case SkyrimMajorRecord_FieldIndex.FormVersion:
                    return (GameSetting_FieldIndex)((int)index);
                case SkyrimMajorRecord_FieldIndex.Version2:
                    return (GameSetting_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        public static new GameSetting_FieldIndex ConvertFieldIndex(MajorRecord_FieldIndex index)
        {
            switch (index)
            {
                case MajorRecord_FieldIndex.MajorRecordFlagsRaw:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.FormKey:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.VersionControl:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.EditorID:
                    return (GameSetting_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IGameSettingGetter? lhs,
            IGameSettingGetter? rhs)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((ISkyrimMajorRecordGetter)lhs, (ISkyrimMajorRecordGetter)rhs)) return false;
            return true;
        }
        
        public override bool Equals(
            ISkyrimMajorRecordGetter? lhs,
            ISkyrimMajorRecordGetter? rhs)
        {
            return Equals(
                lhs: (IGameSettingGetter?)lhs,
                rhs: rhs as IGameSettingGetter);
        }
        
        public override bool Equals(
            IMajorRecordGetter? lhs,
            IMajorRecordGetter? rhs)
        {
            return Equals(
                lhs: (IGameSettingGetter?)lhs,
                rhs: rhs as IGameSettingGetter);
        }
        
        public virtual int GetHashCode(IGameSettingGetter item)
        {
            var hash = new HashCode();
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(ISkyrimMajorRecordGetter item)
        {
            return GetHashCode(item: (IGameSettingGetter)item);
        }
        
        public override int GetHashCode(IMajorRecordGetter item)
        {
            return GetHashCode(item: (IGameSettingGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return GameSetting.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormKey> GetLinkFormKeys(IGameSettingGetter obj)
        {
            foreach (var item in base.GetLinkFormKeys(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        public void RemapLinks(IGameSettingGetter obj, IReadOnlyDictionary<FormKey, FormKey> mapping) => throw new NotImplementedException();
        partial void PostDuplicate(GameSetting obj, GameSetting rhs, Func<FormKey> getNextFormKey, IList<(IMajorRecordCommon Record, FormKey OriginalFormKey)>? duplicatedRecords);
        
        public override IMajorRecordCommon Duplicate(IMajorRecordCommonGetter item, Func<FormKey> getNextFormKey, IList<(IMajorRecordCommon Record, FormKey OriginalFormKey)>? duplicatedRecords)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        
    }
    public partial class GameSettingSetterTranslationCommon : SkyrimMajorRecordSetterTranslationCommon
    {
        public new static readonly GameSettingSetterTranslationCommon Instance = new GameSettingSetterTranslationCommon();

        #region DeepCopyIn
        public virtual void DeepCopyIn(
            IGameSettingInternal item,
            IGameSettingGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                item,
                rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
        }
        
        public virtual void DeepCopyIn(
            IGameSetting item,
            IGameSettingGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (ISkyrimMajorRecord)item,
                (ISkyrimMajorRecordGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
        }
        
        public override void DeepCopyIn(
            ISkyrimMajorRecordInternal item,
            ISkyrimMajorRecordGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IGameSettingInternal)item,
                rhs: (IGameSettingGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        public override void DeepCopyIn(
            ISkyrimMajorRecord item,
            ISkyrimMajorRecordGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IGameSetting)item,
                rhs: (IGameSettingGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        public override void DeepCopyIn(
            IMajorRecordInternal item,
            IMajorRecordGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IGameSettingInternal)item,
                rhs: (IGameSettingGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        public override void DeepCopyIn(
            IMajorRecord item,
            IMajorRecordGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IGameSetting)item,
                rhs: (IGameSettingGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public GameSetting DeepCopy(
            IGameSettingGetter item,
            GameSetting.TranslationMask? copyMask = null)
        {
            GameSetting ret = (GameSetting)((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).GetNew();
            ((GameSettingSetterTranslationCommon)((IGameSettingGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public GameSetting DeepCopy(
            IGameSettingGetter item,
            out GameSetting.ErrorMask errorMask,
            GameSetting.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            GameSetting ret = (GameSetting)((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).GetNew();
            ((GameSettingSetterTranslationCommon)((IGameSettingGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = GameSetting.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public GameSetting DeepCopy(
            IGameSettingGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            GameSetting ret = (GameSetting)((GameSettingCommon)((IGameSettingGetter)item).CommonInstance()!).GetNew();
            ((GameSettingSetterTranslationCommon)((IGameSettingGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim
{
    public partial class GameSetting
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => GameSetting_Registration.Instance;
        public new static GameSetting_Registration Registration => GameSetting_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => GameSettingCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return GameSettingSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => GameSettingSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class GameSettingBinaryWriteTranslation :
        SkyrimMajorRecordBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static GameSettingBinaryWriteTranslation Instance = new GameSettingBinaryWriteTranslation();

        public virtual void Write(
            MutagenWriter writer,
            IGameSettingGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            using (HeaderExport.Header(
                writer: writer,
                record: recordTypeConverter.ConvertToCustom(RecordTypes.GMST),
                type: Mutagen.Bethesda.Binary.ObjectType.Record))
            {
                SkyrimMajorRecordBinaryWriteTranslation.WriteEmbedded(
                    item: item,
                    writer: writer);
                MajorRecordBinaryWriteTranslation.WriteRecordTypes(
                    item: item,
                    writer: writer,
                    recordTypeConverter: recordTypeConverter);
            }
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IGameSettingGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            ISkyrimMajorRecordGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IGameSettingGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IMajorRecordGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IGameSettingGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class GameSettingBinaryCreateTranslation : SkyrimMajorRecordBinaryCreateTranslation
    {
        public new readonly static GameSettingBinaryCreateTranslation Instance = new GameSettingBinaryCreateTranslation();

        public override RecordType RecordType => throw new ArgumentException();
    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class GameSettingBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class GameSettingBinaryOverlay :
        SkyrimMajorRecordBinaryOverlay,
        IGameSettingGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => GameSetting_Registration.Instance;
        public new static GameSetting_Registration Registration => GameSetting_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => GameSettingCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => GameSettingSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => GameSettingBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((GameSettingBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected GameSettingBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }


        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            GameSettingMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IGameSettingGetter rhs)) return false;
            return ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IGameSettingGetter? obj)
        {
            return ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((GameSettingCommon)((IGameSettingGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

