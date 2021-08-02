using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_damage_burst", menuName = "Abilities/Effects/Burst Damage")]
    public class BurstDamageEffect : EffectStrategy
    {
        [SerializeField] private float damage;
        
        public override void ApplyEffect(GameObject caster, IEnumerable<GameObject> targets, Action callback)
        {
            foreach (var target in targets)
            {
                var health = (CharacterHealth) target.GetComponent(typeof(CharacterHealth));
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }
    }
}