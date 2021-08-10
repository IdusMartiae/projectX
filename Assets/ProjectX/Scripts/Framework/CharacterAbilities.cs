using System;
using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(Animator))]
    public abstract class CharacterAbilities : MonoBehaviour
    {
        public abstract Dictionary<AbilitySlotType, AbilitySlot> Abilities { get; set; }
        
        public event Action<AbilitySlotType> AbilityUsed;
        public event Action<AbilitySlotType> AbilityCanceled;

        protected void Start()
        {
            InitializeSlots();
        }

        protected void HandleAbilityUsed(AbilitySlotType abilitySlotType)
        {
            Abilities[abilitySlotType].UseAbility();
            AbilityUsed!(abilitySlotType);
        }

        protected void HandleAbilityCanceled(AbilitySlotType abilitySlotType)
        {
            Abilities[abilitySlotType].CancelAbility();
            AbilityCanceled!(abilitySlotType);
        }

        protected abstract void InitializeSlots();
    }
}