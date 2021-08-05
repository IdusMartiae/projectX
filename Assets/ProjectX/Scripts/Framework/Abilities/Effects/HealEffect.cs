using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_heal", menuName = "Abilities/Effects/Heal", order = -2)]
    public class HealEffect : EffectStrategy
    {
        [SerializeField] private float health;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            try
            {
                foreach (var target in data.Targets)
                {
                    var targetHealthComponent = target.GetComponent<CharacterHealth>();
                    targetHealthComponent.Heal(health);
                }
            }
            catch (Exception e)
            {
                Debug.Log($"{e}: Failed to find target health component");
            }
            finally
            {
                callback();
            }
        }
    }
}