/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using Loqui;

namespace Mutagen.Bethesda.Oblivion
{
    /// <summary>
    /// A static class to house initialization warmup logic
    /// </summary>
    public static class WarmupOblivion
    {
        /// <summary>
        /// Will initialize internals in a more efficient way that avoids reflection.
        /// Not required to call, but can be used to warm up ahead of time.
        /// <br/><br/>NOTE: Calling this warmup which is for a single game, will require you warm up
        /// other games in the same fashion.  Use WarmupAll if you want all games to be warmed.
        /// </summary>
        public static void Init()
        {
            Loqui.Initialization.SpinUp(
                new ProtocolDefinition_Bethesda(),
                new ProtocolDefinition_Oblivion());
            Mutagen.Bethesda.Core.LinkInterfaceMapping.AutomaticRegistration = false;
            Mutagen.Bethesda.Core.LinkInterfaceMapping.Register(new Mutagen.Bethesda.Oblivion.Internals.LinkInterfaceMapping());
        }
    }
}