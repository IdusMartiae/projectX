using System.Collections.Generic;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Framework.Abilities;
using UnityEngine;
using Zenject;
using AbilitySlot = ProjectX.Scripts.Tools.Enums.AbilitySlot;

namespace ProjectX.Scripts.Player
{
    public class PlayerAbilities : CharacterAbilities
    {
        [SerializeField] private Ability primaryAbility;
        [SerializeField] private Ability secondaryAbility;
        [SerializeField] private Ability firstAbility;
        [SerializeField] private Ability secondAbility;
        [SerializeField] private Ability thirdAbility;

        protected override Dictionary<AbilitySlot, Framework.AbilitySlot> Abilities { get; set; } =
            new Dictionary<AbilitySlot, Framework.AbilitySlot>();

        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            inputSystem.SlotDown += HandleAbilityUsed;
            inputSystem.SlotUp += HandleAbilityCanceled;
        }
        
        protected override void InitializeSlots()
        {
           Abilities.Add(AbilitySlot.Primary, new Framework.AbilitySlot(gameObject, primaryAbility));
           Abilities.Add(AbilitySlot.Secondary, new Framework.AbilitySlot(gameObject, secondaryAbility));
           Abilities.Add(AbilitySlot.First, new Framework.AbilitySlot(gameObject, firstAbility));
           Abilities.Add(AbilitySlot.Second, new Framework.AbilitySlot(gameObject, secondAbility));
           Abilities.Add(AbilitySlot.Third, new Framework.AbilitySlot(gameObject, thirdAbility));
        }
    }
}