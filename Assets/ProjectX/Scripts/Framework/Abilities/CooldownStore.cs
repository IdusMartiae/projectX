using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public class CooldownStore : MonoBehaviour
    {   
        private readonly Dictionary<Ability, float> _cooldownTimers = new Dictionary<Ability, float>();
        private readonly Dictionary<Ability, float> _abilityCooldowns = new Dictionary<Ability, float>();
        
        private void Update()
        {
            // TODO Can be optimezed
            var keys = new List<Ability>(_cooldownTimers.Keys);
            
            foreach (var ability in keys)
            {
                _cooldownTimers[ability] -= Time.deltaTime;
                
                if (_cooldownTimers[ability] < 0)
                {
                    _cooldownTimers.Remove(ability);
                    _abilityCooldowns.Remove(ability);
                }
            }
        }

        public void StartCooldown(Ability ability, float cooldownTime)
        {
            _cooldownTimers[ability] = cooldownTime;
            _abilityCooldowns[ability] = cooldownTime;
        }

        public float GetCooldownTimeRemaining(Ability ability)
        {
            if (!_cooldownTimers.ContainsKey(ability))
            {
                return 0;
            }

            return _cooldownTimers[ability];
        }

        public float GetPercentageRemaining(Ability ability)
        {
            if (ability == null)
            {
                return 0;
            }
            
            if (!_cooldownTimers.ContainsKey(ability))
            {
                return 0;
            }

            return _cooldownTimers[ability] / _abilityCooldowns[ability];
        }
    }
}