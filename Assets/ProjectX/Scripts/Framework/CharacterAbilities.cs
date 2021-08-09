using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(Animator))]
    public abstract class CharacterAbilities : MonoBehaviour
    {
        protected abstract Dictionary<Tools.Enums.AbilitySlot, AbilitySlot> Abilities { get; set; }

        public event Action<Tools.Enums.AbilitySlot> AbilityUsed;
        public event Action<Tools.Enums.AbilitySlot> AbilityCanceled;

        protected void Start()
        {
            InitializeSlots();
        }

        protected void HandleAbilityUsed(Tools.Enums.AbilitySlot abilitySlot)
        {
           Abilities[abilitySlot].UseAbility();
           AbilityUsed!(abilitySlot);
        }

        protected void HandleAbilityCanceled(Tools.Enums.AbilitySlot abilitySlot)
        {
            Abilities[abilitySlot].CancelAbility();
            AbilityCanceled!(abilitySlot);
        }

        protected abstract void InitializeSlots();
    }
}