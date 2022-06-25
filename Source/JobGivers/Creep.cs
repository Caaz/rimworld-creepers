using RimWorld;
using Verse;
using Verse.AI;

namespace Creepers.JobGiver
{
    internal class Creep : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            Pawn target = GetAttackableTarget(pawn);
            if (target == null) return null;
            return JobMaker.MakeJob(JobDefOf.Creepers_Creep, target);
        }
        public Pawn GetAttackableTarget(Pawn pawn, float distance = 10f)
        {
            foreach (Thing thing in GenRadial.RadialDistinctThingsAround(pawn.Position, pawn.Map, distance, true))
                if (AcceptablePrey(pawn, thing))
                    return (Pawn)thing;
            return null;
        }
        public bool AcceptablePrey(Pawn hunter, Thing prey)
        {
            if (
                prey == null
                || hunter == null
                || prey == hunter
                || prey.def.thingClass != typeof(Pawn)
            )
                return false;

            Pawn target = (Pawn)prey;

            return !(
                target.Dead
                || !hunter.CanSee(target)
                || !hunter.CanReach(target, PathEndMode.OnCell, Danger.Deadly)
            );
        }
    }
}