using Enums;

namespace StateMachines.Decisions.MovementDecisions
{
    public class BlockingAbilityUsedDecision : BaseDecision
    {
        private readonly CharacterAbilitySlotsComponent _abilitySlotsComponent;
        private bool _blocking;
        
        public BlockingAbilityUsedDecision(
            InputSystem inputSystem,
            CharacterAbilitySlotsComponent abilitySlotsComponent)
        {
            inputSystem.AbilitySlotPressed += CheckAbilityBlocking;
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