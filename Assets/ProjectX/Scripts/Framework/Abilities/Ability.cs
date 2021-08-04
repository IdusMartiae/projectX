using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ProjectX.Scripts.Framework.Abilities.Effects;
using ProjectX.Scripts.Framework.Abilities.Filtering;
using ProjectX.Scripts.Framework.Abilities.Targeting;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    [CreateAssetMenu(fileName = "ability_default", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject, IAbility
    {
        [Header("Common")] [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected AnimationClip animation;

        [Header("Parameters")] 
        [SerializeField] protected float duration;
        [SerializeField] protected float cooldown;
        [SerializeField] private TargetingStrategy targeting;
        [SerializeField] private FilterStrategy[] filters;
        [SerializeField] private EffectStrategy[] effects;
        [SerializeField] private string message;
        
        private GameObject _player;
        private bool _onCooldown;

        // TODO: DELETE USES OF PLAYER DEPENDENCY LATER
        
        public void Use()
        {
            targeting.AcquireTargets(_player, PrintTargets);
        }

        public void Cancel()
        {
        }
        
        public void Initialize(AbilitySlot abilitySlot)
        {
            _player = abilitySlot.PlayerTransform.gameObject;
            targeting.InitializeTargeting(_player);
        }

        public void Deinitialize()
        {
        }
        
        // TODO REPLACE WITH ACTUALLY USEFUL CALLBACK
        private void PrintTargets(IEnumerable<GameObject> targetObjects)
        {
            if (filters != null)
            {
                targetObjects = filters.Aggregate(
                    targetObjects, (current, strategy) => strategy.Filter(current));
            }

            if (effects != null)
            {
                foreach (var effect in effects)
                {
                    effect.ApplyEffect(_player, targetObjects, () => { });
                }
            }

        }
    }
}