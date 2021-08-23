using System.Collections.Generic;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    public class PlayerAbilitiesPanelUI : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlotUI> abilitySlots;

        private readonly Dictionary<AbilitySlotEnum, AbilitySlotUI> _abilitySlotsUI =
            new Dictionary<AbilitySlotEnum, AbilitySlotUI>();

        private CharacterAbilities _playerAbilities;

        [Inject]
        private void Construct(Player.Player player)
        {
            _playerAbilities = player.GetComponent<CharacterAbilities>();
        }

        private void Awake()
        {
            foreach (var abilitySlot in abilitySlots)
            {
                _abilitySlotsUI[abilitySlot.SlotEnum] = abilitySlot;
            }
        }

        private void Start()
        {
            InitializeAbilitySlots();
        } 

        private void Update()
        {
            foreach (var abilitySlot in _abilitySlotsUI.Values)
            {
                abilitySlot.UpdateUI();
            }
        }

        public void ChangeAbilityInSlot(AbilitySlotEnum slot)
        {
            _abilitySlotsUI[slot].UpdateUI();
        }

        private void InitializeAbilitySlots()
        {
            foreach (var abilitySlotUI in _abilitySlotsUI.Values)
            {
                abilitySlotUI.SetAbility(_playerAbilities.GetAbilitySlots()[abilitySlotUI.SlotEnum].GetAbility());
            }
        }
    }
}