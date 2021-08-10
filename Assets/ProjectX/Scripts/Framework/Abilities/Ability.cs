using System.Linq;
using ProjectX.Scripts.Framework.Abilities.Effects;
using ProjectX.Scripts.Framework.Abilities.Filtering;
using ProjectX.Scripts.Framework.Abilities.Targeting;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    [CreateAssetMenu(fileName = "base_ability", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject, IAbility
    {
        [Header("Common")] 
        [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected AnimationClip animation;

        [Header("Parameters")] 
        [SerializeField] protected float duration;
        [SerializeField] protected float cooldown;
        [SerializeField] private TargetingStrategy targeting;
        [SerializeField] private FilterStrategy[] filters;
        [SerializeField] private EffectStrategy[] effects;

        public Sprite Icon => icon;
        public float Duration => duration;
        public float Cooldown => cooldown;

        private AbilityData _abilityData;
        private bool _onCooldown;
        
        public void Use()
        {
            if (targeting == null) return;
            targeting.AcquireTargets(_abilityData, () =>
            {
                PrintTargets(_abilityData);
            });
        }

        public void Cancel()
        {
        }

        public void Initialize(GameObject user)
        {
            _abilityData = new AbilityData(user);
        }

        public void Deinitialize()
        {
        }

        // TODO REPLACE WITH ACTUALLY USEFUL CALLBACK
        private void PrintTargets(AbilityData data)
        {
            if (filters != null)
            {
                data.Targets = filters.Aggregate(data.Targets, (current, strategy) => strategy.Filter(current));
            }

            if (effects != null)
            {
                foreach (var effect in effects)
                {
                    effect.ApplyEffect(data, () => { });
                }
            }
        }
    }
}