using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_heal", menuName = "Abilities/Effects/Heal", order = 200)]
    public class HealEffect : EffectStrategy
    {
        [SerializeField] private float health;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            foreach (var target in data.Targets)
            {
                var targetHealthComponent = target.GetComponent<CharacterHealth>();
                targetHealthComponent.Heal(health);
            }

            callback();
        }
    }
}