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
        
        private InputSystem _inputSystem;
        private Dictionary<SlotType, SkillSlot> _playerAbilities = new Dictionary<SlotType, SkillSlot>();
        
        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            _inputSystem.SlotUp += HandleSlotUp;
            _inputSystem.SlotDown += HandleSlotDown;
            
            InitializeSlots();
        }

        private void HandleSlotUp(SlotType slot)
        {

        }

        private void HandleSlotDown(SlotType slot)
        {

        }

        private void InitializeSlots()
        {
            _playerAbilities.Add(SlotType.Primary, new SkillSlot(gameObject, primary));
            _playerAbilities.Add(SlotType.Secondary, new SkillSlot(gameObject, secondary));
            _playerAbilities.Add(SlotType.Slot1, new SkillSlot(gameObject, slot1));
            _playerAbilities.Add(SlotType.Slot2, new SkillSlot(gameObject, slot2));
        }
    }
}