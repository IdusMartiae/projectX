using System;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_look_at_target", menuName = "Abilities/Effects/Look At Target")]
    public class LookAtTargetEffect : EffectStrategy
    {
        public override void ApplyEffect(AbilityData data, Action callback)
        {
            data.User.transform.LookAt(MouseWorldPosition.GetCoordinates());
        }
    }
}