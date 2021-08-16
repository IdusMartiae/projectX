using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public class AbilityData
    {
        public GameObject User { get; }
        public IEnumerable<GameObject> Targets { get; set; }
        public CharacterAbilities UserAbilitiesComponent { get; }
        public AbilitySlotEnum SlotType { get; }

        public AbilityData(GameObject user, AbilitySlotEnum slotType)
        {
            User = user;
            SlotType = slotType;
            UserAbilitiesComponent = user.GetComponent<CharacterAbilities>();
        }
    }
}