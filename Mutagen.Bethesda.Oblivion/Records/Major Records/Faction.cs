using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class Faction
    {
        [Flags]
        public enum FactionFlag
        {
            HiddenFromPlayer = 0x01,
            Evil = 0x02,
            SpecialCombat = 0x04
        }
    }
}
