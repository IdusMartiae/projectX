using System.Collections.Generic;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Player
{
    public class PlayerAbilities : CharacterAbilities
    {
        [SerializeField] private Ability primaryAbility;
        [SerializeField] private Ability secondaryAbility;
        [SerializeField] private Ability firstAbility;
        [SerializeField] private Ability secondAbility;
        [SerializeField] private Ability thirdAbility;

        public override Dictionary<AbilitySlotType, AbilitySlot> Abilities { get; set; } =
            new Dictionary<AbilitySlotType, AbilitySlot>();
        
        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            inputSystem.SlotDown += HandleAbilityUsed;
            inputSystem.SlotUp += HandleAbilityCanceled;
        }
        
        protected override void InitializeSlots()
        {
           Abilities.Add(AbilitySlotType.Primary, new AbilitySlot(gameObject, primaryAbility));
           Abilities.Add(AbilitySlotType.Secondary, new AbilitySlot(gameObject, secondaryAbility));
           Abilities.Add(AbilitySlotType.First, new AbilitySlot(gameObject, firstAbility));
           Abilities.Add(AbilitySlotType.Second, new AbilitySlot(gameObject, secondAbility));
           Abilities.Add(AbilitySlotType.Third, new AbilitySlot(gameObject, thirdAbility));
        }
    }
}