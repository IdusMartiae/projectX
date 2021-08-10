using System.Collections.Generic;
using ProjectX.Scripts.Player;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    public class PlayerAbilitiesPanelUI : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlotUI>abilitySlots;

        private PlayerAbilities _playerAbilities;
        
        [Inject]
        private void Construct(Player.Player player)
        {
            _playerAbilities = player.GetComponent<PlayerAbilities>();
        }

        private void Start()
        {
            foreach (var abilitySlot in abilitySlots)
            {
                abilitySlot.InitializeAbility(_playerAbilities.Abilities[abilitySlot.GetSlotType()]);
            }
        }
    }
}
