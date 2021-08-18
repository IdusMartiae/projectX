using System;
using System.Linq;
using ProjectX.Scripts.Framework.Abilities.Effects;
using ProjectX.Scripts.Framework.Abilities.Filtering;
using ProjectX.Scripts.Framework.Abilities.Targeting;
using ProjectX.Scripts.Player;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    [CreateAssetMenu(fileName = "base_ability", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject
    {
        [Header("Common")] 
        [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;
        [SerializeField, Multiline(5)] protected string description;

        [Header("Parameters")] 
        [SerializeField] protected float duration;
        [SerializeField] protected float cooldown;
        [SerializeField] private TargetingStrategy targeting;
        [SerializeField] private FilterStrategy[] filters;
        [SerializeField] private EffectStrategy[] effects;

        private AbilityData _abilityData;
        
        public Sprite Icon => icon;
        
        public void Initialize(GameObject user, AbilitySlot abilitySlot)
        {
            _abilityData = new AbilityData(user, abilitySlot);
        }

        public void Use(Action callback)
        {
            var cooldownStore = _abilityData.User.GetComponent<CooldownStore>();
            
            if (cooldownStore.GetCooldownTimeRemaining(this) > 0)
            {
                return;
            }
            
            if (targeting == null) return;
            
            targeting.AcquireTargets(_abilityData, () =>
                {
                    cooldownStore.StartCooldown(this, cooldown);
                    ApplyFilters(_abilityData);
                    ApplyEffects(_abilityData);
                }
            );
        }

        private void ApplyFilters(AbilityData data)
        {
            if (filters == null)
            {
                return;
            }
            
            data.Targets = filters.Aggregate(data.Targets, (current, strategy) => strategy.Filter(current));
        }

        private void ApplyEffects(AbilityData data)
        {
            foreach (var effect in effects)
            {
                effect.ApplyEffect(data, () => { });
            }
        }
    }
}