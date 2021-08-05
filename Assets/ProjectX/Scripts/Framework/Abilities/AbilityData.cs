using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public class AbilityData
    {
        public GameObject User { get; }
        public IEnumerable<GameObject> Targets { get; set; }
        public CharacterAbilities UserAbilitiesComponent { get; }

        public AbilityData(GameObject user)
        {
            User = user;
            UserAbilitiesComponent = user.GetComponent<CharacterAbilities>();
        }
    }
}