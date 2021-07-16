using Enums;

namespace StateMachines.Decisions.AimDecisions
{
    public class AimedAbilityCancelledDecision : BaseDecision
    {
        private readonly CharacterAbilitySlotsComponent _abilitySlotsComponent;
        private bool _aimed;
        
        public AimedAbilityCancelledDecision(
            InputSystem inputSystem,
            CharacterAbilitySlotsComponent abilitySlotsComponent)
        {
            inputSystem.AbilitySlotReleased += CheckAbilityAim;
            _abilitySlotsComponent = abilitySlotsComponent;
        }
        
        public override bool Decide()
        {
            if (_aimed)
            {
                _aimed = false;
                
                return true;
            }
            
            return false;
        }
        
        private void CheckAbilityAim(AbilitySlotType slot)
        {
            _aimed = _abilitySlotsComponent.AbilitySlots[slot].SlotAbility.Aimed;
        }
    }
}