using System;
using System.Linq;
using ProjectX.Scripts.Environment.UI;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools.Enums;
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
                playerAbilities.UseAbilityInSlot(abilitySlotPair.Key,
                    GetCombatInteractionCallback(abilitySlotPair.Key));

                return true;
            }

            return false;
        }

        private Action<AbilityPhase> GetCombatInteractionCallback(AbilitySlotEnum slot)
        {
            return (AbilityPhase abilityPhase) =>
            {
                switch (abilityPhase)
                {
                    case AbilityPhase.Active:
                        break;
                    case AbilityPhase.AcquiredTargets:
                        break;
                    case AbilityPhase.AppliedFilters:
                        break;
                    case AbilityPhase.AppliedEffects:
                        break;
                }
            };
        }
        
        private void MovementInteraction()
        {
        }

    }
}