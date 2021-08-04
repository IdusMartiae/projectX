using System;
using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_heal_percent", menuName = "Abilities/Effects/Percentage Heal", order = -3)]
    public class PercentHealEffect : EffectStrategy
    {
        [SerializeField] private PercentageType percentageType;
        [SerializeField] private float percent;
        
        public override void ApplyEffect(GameObject caster, IEnumerable<GameObject> targets, Action callback)
        {
            try
            {
                foreach (var target in targets)
                {
                    var targetHealthComponent = target.GetComponent<CharacterHealth>();
                    targetHealthComponent.Heal(percent, percentageType);
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