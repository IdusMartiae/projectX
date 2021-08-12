using System;
using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.Wrappers;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class CharacterAbilities : MonoBehaviour
    {
        [SerializeField] private List<SerializableAbilitySlotWrapper> abilitySlotWrappers;

        private Dictionary<AbilitySlotEnum, AbilitySlot> _abilitySlots = new Dictionary<AbilitySlotEnum, AbilitySlot>();
    
        private void Start()
        {
            foreach (var abilitySlot in abilitySlotWrappers)
            {
                _abilitySlots.Add(abilitySlot.SlotEnum, new AbilitySlot(gameObject, abilitySlot.Ability));
            }
        }

        public void UseAbilityInSlot(AbilitySlotEnum slot, Action<AbilityPhase> callback)
        {
            _abilitySlots[slot].UseAbility(callback);
        }

        public Dictionary<AbilitySlotEnum, AbilitySlot> GetAbilitySlots()
        {
            return _abilitySlots;
        }
    }
}