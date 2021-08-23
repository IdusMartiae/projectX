using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_trigger_animation", menuName = "Abilities/Effects/Trigger Animation")]
    public class TriggerAnimationEffect : EffectStrategy
    {
        [SerializeField] private AnimationClip animation;
        private Animator _animator;

        public override void ApplyEffect(AbilityData data, Action callback)
        {
            if (_animator == null)
            {
                _animator = data.User.GetComponent<Animator>();
                var animatorOverrideController= (AnimatorOverrideController) _animator.runtimeAnimatorController;
                animatorOverrideController[data.AbilitySlot.GetDefaultAnimation()] = animation;
            }
            
            _animator.SetTrigger(data.TriggerName);
            callback();
        }
        
    }
}