﻿using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda.Internals
{
    public static class MutagenRemoveExt
    {
        public static void Remove<TItem>(this IExtendedList<TItem>? enumer, HashSet<FormKey> removeSet)
            where TItem : IMajorRecordCommonGetter
        {
            enumer.Remove((i) => removeSet.Contains(i.FormKey));
        }
    }
}
