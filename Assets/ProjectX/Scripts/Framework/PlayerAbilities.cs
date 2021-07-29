using System.Collections.Generic;
using ProjectX.Scripts.Player;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAbilities : MonoBehaviour
    {
        [SerializeField] private BaseSkill primary;
        [SerializeField] private BaseSkill secondary;
        [SerializeField] private BaseSkill slot1;
        [SerializeField] private BaseSkill slot2;
        
        private Dictionary<SlotType, SkillSlot> _playerAbilities = new Dictionary<SlotType, SkillSlot>();
        
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
            _playerAbilities[slot].UseSkill();
        }

        private void HandleSlotDown(SlotType slot)
        {
            _playerAbilities[slot].CancelSkill();
        }

        private void InitializeSlots()
        {
            _playerAbilities.Add(SlotType.Primary, new SkillSlot(gameObject, primary, "Primary"));
            _playerAbilities.Add(SlotType.Secondary, new SkillSlot(gameObject, secondary, "Secondary"));
            _playerAbilities.Add(SlotType.Slot1, new SkillSlot(gameObject, slot1, "Slot1"));
            _playerAbilities.Add(SlotType.Slot2, new SkillSlot(gameObject, slot2, "Slot2"));
        }
    }
}