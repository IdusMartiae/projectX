using Enums;
using UnityEngine;

namespace StateMachines.Decisions
{
    public class BlockingAbilityUsedDecision : BaseDecision
    {
        private readonly CharacterAbilitiesComponent _abilitiesComponent;
        private bool _blocking;
        
        public BlockingAbilityUsedDecision(
            InputSystem inputSystem,
            CharacterAbilitiesComponent abilitiesComponent)
        {
            inputSystem.AbilityStarted += CheckAbilityBlocking;
            _abilitiesComponent = abilitiesComponent;
        }
        
        public override bool Decide()
        {
            if (_blocking)
            {
                _blocking = false;

                return true;
            }
            
            return false;
        }
        
        private void CheckAbilityBlocking(AbilitySlotType slot)
        {
            _blocking = _abilitiesComponent._abilitySlots[slot].SlotAbility.MovementBlocking;
        }
    }
}