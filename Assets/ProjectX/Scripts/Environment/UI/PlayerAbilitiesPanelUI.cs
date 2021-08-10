using System.Collections.Generic;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Environment.UI
{
    // TODO THIS SCRIPT SHOULD HAVE REFS TO ABILITY SLOTS AND TAKE ABILITY INFO FROM PLAYER ABILITIES COMPONENT
    public class PlayerAbilitiesPanelUI : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlotUI> abilitySlotUIs;
        
        private Dictionary<AbilitySlotEnum, AbilitySlotUI> _abilitiesUI;

        private void Start()
        {
            _abilitiesUI = new Dictionary<AbilitySlotEnum, AbilitySlotUI>();
            foreach (var abilitySlot in abilitySlotUIs)
            {
                _abilitiesUI.Add(abilitySlot.GetSlotType(), abilitySlot);
            }
        }

        public void UseAbilityInSlot(AbilitySlotEnum abilitySlotEnum)
        {
        }
            
        public void ChangeAbilityInSlot(AbilitySlotEnum abilitySlotEnum, IAbility newAbility)
        {
            //_abilitiesUI[abilitySlotType].ChangeAbility(newAbility);
        }

    }
}