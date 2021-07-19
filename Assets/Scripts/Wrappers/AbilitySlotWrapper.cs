using UnityEngine;

namespace Wrappers
{
    public class AbilitySlotWrapper
    {
        private bool _isActilve;
        private float _cooldownTimer;

        public BaseAbility SlotAbility { get; set; }

        public AbilitySlotWrapper(BaseAbility ability)
        {
            SlotAbility = ability;
        }

        public void UpdateCooldownTimer()
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer < 0 )
            {
                _cooldownTimer = 0f;
                _isActilve = true;
            }
        }

        public void UseAbility()
        {
            if (_cooldownTimer == 0)
            {
                SlotAbility.Start();
            }
        }

        public void AbilityRelease()
        {
            SlotAbility.Finish();
        }
        
    }
}