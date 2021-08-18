﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_delayed_effects", menuName = "Abilities/Effects/Delayed effects")]
    public class DelayedEffectsEffect : EffectStrategy
    {
        [SerializeField] private float delayTime;
        [SerializeField] private List<EffectStrategy> effectStrategies;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            data.StartCoroutine(DelayEffects(data, callback));
        }

        private IEnumerator DelayEffects(AbilityData data, Action callback)
        {
            yield return new WaitForSeconds(delayTime);
            
            foreach (var effect in effectStrategies)
            {
                effect.ApplyEffect(data, callback);
            }

            callback();
        }
    }
}