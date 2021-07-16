using Enums;

namespace StateMachines.Decisions.MovementDecisions
{
    public class BlockingAbilityCancelledDecision : BaseDecision
    {
        private readonly CharacterAbilitySlotsComponent _abilitySlotsComponent;
        private bool _blocking;

        public BlockingAbilityCancelledDecision(
            InputSystem inputSystem,
            CharacterAbilitySlotsComponent abilitySlotsComponent)
        {
            inputSystem.AbilitySlotReleased += CheckAbilityBlocking;
            _abilitySlotsComponent = abilitySlotsComponent;
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
            _blocking = _abilitySlotsComponent.AbilitySlots[slot].SlotAbility.MovementBlocking;
        }
    }
}