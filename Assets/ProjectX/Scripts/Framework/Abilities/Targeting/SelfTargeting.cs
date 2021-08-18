using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_self", menuName = "Abilities/Targeting/Self")]
    public class SelfTargeting : TargetingStrategy
    {
        public override void AcquireTargets(AbilityData data, Action callback)
        {
            data.TargetedPoint = data.User.transform.position;
            data.Targets = new[] {data.User};
            callback();
        }
    }
}