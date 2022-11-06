using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Creepers.JobDrivers
{
    internal class Creep : Verse.AI.JobDriver
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }
        protected override IEnumerable<Toil> MakeNewToils()
        {
            AddFailCondition((Func<bool>)delegate
            {
                return (TargetA.Thing == null || TargetA.ThingDestroyed);
            });
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.OnCell).FailOnDespawnedOrNull(TargetIndex.A);
            yield return Toils_General.Do(Explode);
        }
        private void Explode()
        {
            // Do a boom
            try
            {
                GenExplosion.DoExplosion(pawn.Position, pawn.Map, 1.9f, DamageDefOf.Bomb, pawn, 300, 0, SoundDefOf.Interact_Ignite);
                pawn.Destroy();
            }
            catch (Exception e)
            {
                Log.Message("Failed to explode? " + e);
            }
        }
    }
}