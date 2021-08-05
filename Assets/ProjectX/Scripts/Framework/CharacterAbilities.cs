using System.Collections.Generic;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Player;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAbilities : MonoBehaviour
    {
        [SerializeField] private Ability primary;
        [SerializeField] private Ability secondary;
        [SerializeField] private Ability slot1;
        [SerializeField] private Ability slot2;
        
        private readonly Dictionary<SlotType, AbilitySlot> _playerAbilities = new Dictionary<SlotType, AbilitySlot>();
        
        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            inputSystem.SlotUp += HandleSlotUp;
            inputSystem.SlotDown += HandleSlotDown;
        }

        private void Start()
        {
            InitializeSlots();
        }

        private void HandleSlotUp(SlotType slot)
        {
            _playerAbilities[slot].UseAbility();
        }

        private void HandleSlotDown(SlotType slot)
        {
            _playerAbilities[slot].CancelAbility();
        }

        private void InitializeSlots()
        {
            _playerAbilities.Add(SlotType.Primary, new AbilitySlot(gameObject, primary));
            _playerAbilities.Add(SlotType.Secondary, new AbilitySlot(gameObject, secondary));
            _playerAbilities.Add(SlotType.Slot1, new AbilitySlot(gameObject, slot1));
            _playerAbilities.Add(SlotType.Slot2, new AbilitySlot(gameObject, slot2));
        }
    }
}