using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Player.Abilities.Targeting
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void AcquireTargets(GameObject caster, Action<IEnumerable<GameObject>> callback);
        public abstract void InitializeTargeting(GameObject caster);
    }
}