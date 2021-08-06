using System;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_look_at", menuName = "Abilities/Effects/Look At")]
    public class LookAtEffect : EffectStrategy
    {
        public override void ApplyEffect(AbilityData data, Action callback)
        {
            data.User.transform.LookAt(MouseWorldPosition.GetCoordinates());
        }
    }
}