using Enums;

namespace StateMachines.Decisions
{
    public class AimedAbilityUsedDecision : BaseDecision
    {
        private readonly CharacterAbilitiesComponent _abilitiesComponent;
        private bool _aimed;

        public AimedAbilityUsedDecision(
            InputSystem inputSystem,
            CharacterAbilitiesComponent abilitiesComponent)
        {
            inputSystem.AbilityStarted += CheckAbilityAim;
            _abilitiesComponent = abilitiesComponent;
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
            _aimed = _abilitiesComponent._abilitySlots[slot].SlotAbility.Aimed;
        }
    }
}