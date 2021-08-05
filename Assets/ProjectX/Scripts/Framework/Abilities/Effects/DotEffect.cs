using System;
using System.Collections;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_dot", menuName = "Abilities/Effects/Dot Effect")]
    public class DotEffect : EffectStrategy
    {
        [SerializeField] private EffectStrategy effectToApply;
        [SerializeField] private float duration;
        [SerializeField] private float tickInterval;

        private Coroutine _coroutine;
        
        public override void ApplyEffect(AbilityData data, Action callback)
        {
            if (_coroutine != null)
            {
                data.UserAbilitiesComponent.StopCoroutine(_coroutine);
            }
            _coroutine = data.UserAbilitiesComponent.StartCoroutine(ApplyDot(data, callback));
        }

        private IEnumerator ApplyDot(AbilityData data, Action callback)
        {
            var timer = 0f;
            while (timer < duration)
            {
                effectToApply.ApplyEffect(data, () => {});
                yield return new WaitForSeconds(tickInterval);
                timer += tickInterval;
            }
            
            callback();
        }
    }
}