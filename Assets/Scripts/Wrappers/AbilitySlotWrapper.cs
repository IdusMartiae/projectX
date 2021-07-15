using UnityEngine;

namespace Wrappers
{
    public class AbilitySlotWrapper
    {
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
            }
        }

        public void UseAbility()
        {
            if (_cooldownTimer == 0)
            {
                SlotAbility.Start();
            }
        }
    }
}