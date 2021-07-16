using Enums;

namespace StateMachines.Decisions.AimDecisions
{
    public class AimedAbilityUsedDecision : BaseDecision
    {
        private readonly CharacterAbilitySlotsComponent _abilitySlotsComponent;
        private bool _aimed;

        public AimedAbilityUsedDecision(
            InputSystem inputSystem,
            CharacterAbilitySlotsComponent abilitySlotsComponent)
        {
            inputSystem.AbilitySlotPressed += CheckAbilityAim;
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