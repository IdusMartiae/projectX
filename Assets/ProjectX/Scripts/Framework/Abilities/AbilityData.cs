using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public class AbilityData
    {
        public GameObject User { get; }
        public IEnumerable<GameObject> Targets { get; set; }
        public CharacterAbilities UserAbilitiesComponent { get; }
        public AbilitySlot AbilitySlot { get; }
        public string TriggerName { get; }

        public AbilityData(GameObject user, AbilitySlot abilitySlot)
        {
            User = user;
            AbilitySlot = abilitySlot;
            TriggerName = abilitySlot.GetSlotType().ToString();
            UserAbilitiesComponent = user.GetComponent<CharacterAbilities>();
        }
    }
}