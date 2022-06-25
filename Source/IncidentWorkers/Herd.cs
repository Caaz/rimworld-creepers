using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Creepers.IncidentWorkers
{
    internal class Herd : IncidentWorker
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            if (!PawnsArrivalModeDefOf.EdgeWalkIn.Worker.TryResolveRaidSpawnCenter(parms)) return false;
            float percent = parms.points / 10000;
            List<Pawn> creepers = new List<Pawn>();
            PawnKindDef kind = PawnKindDefOf.Creepers_CreeperPawnKind;
            for (int i = 0; i < (percent * 20); i++)
            {
                Pawn creeper = PawnGenerator.GeneratePawn(kind);
                creeper.ageTracker.AgeBiologicalTicks = 0;
                creeper.ageTracker.AgeChronologicalTicks = 0;
                creeper.health.RemoveAllHediffs();
                creepers.Add(creeper);
            }
            PawnsArrivalModeDefOf.EdgeWalkIn.Worker.Arrive(creepers, parms);
            SendStandardLetter(parms, new TargetInfo(creepers[0].Position, map));
            return true;
        }
    }
}