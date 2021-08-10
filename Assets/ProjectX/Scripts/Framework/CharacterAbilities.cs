using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.Wrappers;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    // TODO THIS IS BASE CHARACTER ABILITIES COMPONENT, MIGHT NEED TO IMPLEMENT PLAYER ABILITIES COMPONENT BECAUSE OF UI DEPENDENCIES
    public class CharacterAbilities : MonoBehaviour
    {
        [SerializeField] private List<SerializableAbilitySlotWrapper> abilitySlots;
        
        private Dictionary<AbilitySlotEnum, AbilitySlot> _abilities;
        
        private void Start()
        {
            InitializeAbilitiesDictionary();
        }
        
        private void InitializeAbilitiesDictionary()
        {
            _abilities = new Dictionary<AbilitySlotEnum, AbilitySlot>();
            foreach (var abilitySlot in abilitySlots)
            {
                _abilities.Add(abilitySlot.SlotEnum, new AbilitySlot(gameObject, abilitySlot.Ability));
            }
        }
    }
}