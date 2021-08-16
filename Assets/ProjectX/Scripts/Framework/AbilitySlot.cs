using System;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    [Serializable]
    public class AbilitySlot
    {
        [SerializeField] private AbilitySlotEnum slotType;
        [SerializeField] private Ability ability;
        
        private GameObject _user;

        public void Initialize(GameObject user)
        {
            _user = user;
            ability.Initialize(_user, slotType);
        }

        public void UseAbility(Action<AbilityPhase> callback)
        {
            ability.Use(callback);
        }

        public void ChangeAbility(Ability newAbility)
        {
            ability = newAbility;
            ability.Initialize(_user, slotType);
        }

        public Ability GetAbility()
        {
            return ability;
        }

        public AbilitySlotEnum GetSlotType()
        {
            return slotType;
        }
    }
}