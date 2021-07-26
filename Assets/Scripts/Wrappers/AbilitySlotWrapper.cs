using UnityEngine;

namespace Wrappers
{
    public class AbilitySlotWrapper
    {
        private readonly CharacterAbilitySlotsComponent _parentComponent;
        private bool _isActilve;
        private Collider _hitBoxInstance;
        private static readonly int PrimaryAbility = Animator.StringToHash("PrimaryAbility");

        public BaseAbility SlotAbility { get; private set; }

        public AbilitySlotWrapper(CharacterAbilitySlotsComponent parentComponent) : this(null, parentComponent)
        {
        }

        public AbilitySlotWrapper(BaseAbility ability, CharacterAbilitySlotsComponent parentComponent)
        {
            _parentComponent = parentComponent;
            SlotAbility = ability;

            InstantiateAbilityHitBox();
        }


        public void UseAbility(Animator animator)
        {
            if (SlotAbility.CooldownTimer != 0) return;
            
            _parentComponent.StartCoroutine(SlotAbility.PerformAbility(_hitBoxInstance));
            _parentComponent.StartCoroutine(SlotAbility.PerformCooldown());
        }

        public void AbilityRelease()
        {
        }

        public void ChangeAbility(BaseAbility newAbility)
        {
            Object.Destroy(_hitBoxInstance.gameObject);
            SlotAbility = newAbility;
            InstantiateAbilityHitBox();
        }

        private void InstantiateAbilityHitBox()
        {
            if (SlotAbility != null)
            {
                _hitBoxInstance = Object.Instantiate(SlotAbility.HitBoxPrefab, _parentComponent.transform);
                _hitBoxInstance.enabled = false;
            }
        }
    }
}