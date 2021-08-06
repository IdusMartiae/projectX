using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_damage", menuName = "Abilities/Effects/Damage", order = 100)]
    public class DamageEffect : EffectStrategy
    {
        [SerializeField] private float damage;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            try
            {
                foreach (var target in data.Targets)
                {
                    var targetHealthComponent = target.GetComponent<CharacterHealth>();
                    targetHealthComponent.TakeDamage(damage);
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