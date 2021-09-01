using System;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_damage_percent", menuName = "Abilities/Effects/Percentage Damage", order = 100)]
    public class PercentDamageEffect : EffectStrategy
    {
        [SerializeField] private PercentageType percentageType;
        [SerializeField] private float percent;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            foreach (var target in data.Targets)
            {
                var targetHealthComponent = target.GetComponent<CharacterHealth>();
                targetHealthComponent.TakeDamage(percent, percentageType);
            }

            callback();
        }
    }
}