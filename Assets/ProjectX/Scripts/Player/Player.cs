using System.Linq;
using ProjectX.Scripts.Framework;
using UnityEngine;

namespace ProjectX.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterAbilities playerAbilities;

        private void Update()
        {
            if (CombatInteraction()) return;

            MovementInteraction();
        }

        private bool CombatInteraction()
        {
            foreach (var abilitySlotPair in playerAbilities.GetAbilitySlots()
                .Where(abilitySlotPair => InputSystem.GetKeyDown(abilitySlotPair.Key)))
            {
                playerAbilities.UseAbilityInSlot(abilitySlotPair.Key, () => { });

                return true;
            }

            return false;
        }

        private void MovementInteraction()
        {
        }
    }
}