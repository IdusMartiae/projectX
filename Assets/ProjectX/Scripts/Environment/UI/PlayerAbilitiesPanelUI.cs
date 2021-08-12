using System;
using System.Collections.Generic;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Environment.UI
{
    public class PlayerAbilitiesPanelUI : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlotUI> abilitySlots;
        [SerializeField] private CharacterAbilities playerAbilities;
        
        private readonly Dictionary<AbilitySlotEnum, AbilitySlotUI> _abilitySlotsUI = new Dictionary<AbilitySlotEnum, AbilitySlotUI>();


        private bool init = false;
        
        private void Start()
        {
            foreach (var abilitySlot in abilitySlots)
            {
                _abilitySlotsUI.Add(abilitySlot.GetSlotType(), abilitySlot);
            }
        }

        private void Update()
        {
            if (init) return;
            InitializeAbilities();
            init = true;
        }

        public void InitializeAbilities()
        {
            foreach (var abilitySlotUI in _abilitySlotsUI)
            {
                abilitySlotUI.Value.SetAbilitySlot(playerAbilities.GetAbilitySlots()[abilitySlotUI.Key]);
            }
        }
        
        public void ChangeAbilityInSlot(AbilitySlotEnum slot, IAbility newAbility)
        {
            //_abilitiesUI[slot].ChangeAbility(newAbility);
        }

    }
}