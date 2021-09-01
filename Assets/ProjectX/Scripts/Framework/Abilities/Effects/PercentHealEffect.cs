using System;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_heal_percent", menuName = "Abilities/Effects/Percentage Heal", order = 200)]
    public class PercentHealEffect : EffectStrategy
    {
        [SerializeField] private PercentageType percentageType;
        [SerializeField] private float percent;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            foreach (var target in data.Targets)
            {
                var targetHealthComponent = target.GetComponent<CharacterHealth>();
                targetHealthComponent.Heal(percent, percentageType);
            }

            callback();
        }
    }
}