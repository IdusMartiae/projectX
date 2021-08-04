using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_dot", menuName = "Abilities/Effects/Dot Effect")]
    public class DotEffect : EffectStrategy
    {
        [SerializeField] private EffectStrategy effectToApply;
        [SerializeField] private float duration;
        [SerializeField] private float tickInterval;

        public override void ApplyEffect(GameObject caster, IEnumerable<GameObject> targets, Action callback)
        {
            caster.GetComponent<CharacterAbilities>().StartCoroutine(ApplyDot(caster, targets, callback));
        }

        private IEnumerator ApplyDot(GameObject caster, IEnumerable<GameObject> targets, Action callback)
        {
            var timer = 0f;
            while (timer < duration)
            {
                effectToApply.ApplyEffect(caster, targets, () => {});
                yield return new WaitForSeconds(tickInterval);
                timer += tickInterval;
            }
            
            callback();
        }
    }
}