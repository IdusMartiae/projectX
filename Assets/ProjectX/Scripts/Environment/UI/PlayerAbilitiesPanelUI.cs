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

        private void Start()
        {
            foreach (var abilitySlot in abilitySlots)
            {
                _abilitySlotsUI.Add(abilitySlot.GetSlotType(), abilitySlot);
                _abilitySlotsUI[abilitySlot.GetSlotType()]
                    .SetAbilitySlot(_playerAbilities.GetAbilitySlots()[abilitySlot.GetSlotType()]);
            }
        }

        private void Update()
        {
        }

        public void ChangeAbilityInSlot(AbilitySlotEnum slot)
        {
            _abilitySlotsUI[slot].UpdateUI();
        }
    }
}