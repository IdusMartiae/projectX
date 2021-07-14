using UnityEngine;

namespace Wrappers
{
    public class AbilitySlotWrapper
    {
        private BaseAbility _slotAbility;
        private float _cooldownTimer;

        public AbilitySlotWrapper(BaseAbility ability)
        {
            _slotAbility = ability;
        }
        
        public void ChangeSlotAbility(BaseAbility ability)
        {
            _slotAbility = ability;
        }

        public void UpdateCooldownTimer()
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer < 0 )
            {
                _cooldownTimer = 0f;
            }
        }

        public void UseAbility()
        {
            if (_cooldownTimer == 0)
            {
                _slotAbility.Start();
            }
        }
    }
}