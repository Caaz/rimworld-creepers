using RimWorld;
using Verse;

namespace Creepers
{
#pragma warning disable 0649
    [DefOf]
    internal static class JobDefOf
    {
        public static JobDef Creepers_Creep;
        static JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RimWorld.JobDefOf));
        }
    }
    [DefOf]
    internal static class PawnKindDefOf
    {
        public static PawnKindDef Creepers_CreeperPawnKind;
        static PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RimWorld.PawnKindDefOf));
        }
    }
}