using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void AcquireTargets(AbilityData data, Action callback);
    }
}