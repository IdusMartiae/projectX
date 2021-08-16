using System;
using System.Collections.Generic;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(CooldownStore))]
    public class CharacterAbilities : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlot> abilitySlots;

        private readonly Dictionary<AbilitySlotEnum, AbilitySlot> _abilitySlotsDictionary = new Dictionary<AbilitySlotEnum, AbilitySlot>();

        private void Awake()
        {
            foreach (var abilitySlot in abilitySlots)
            {
                _abilitySlotsDictionary[abilitySlot.GetSlotType()] = abilitySlot;
                abilitySlot.Initialize(gameObject);
            }
        }
        
        public void UseAbilityInSlot(AbilitySlotEnum slot, Action<AbilityPhase> callback)
        {
            _abilitySlotsDictionary[slot].UseAbility(callback);
        }

        public Dictionary<AbilitySlotEnum, AbilitySlot> GetAbilitySlots()
        {
            return _abilitySlotsDictionary;
        }
    }
}