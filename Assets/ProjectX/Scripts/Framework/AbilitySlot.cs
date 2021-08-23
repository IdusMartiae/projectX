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
        [SerializeField] private AnimationClip defaultAnimation;
        
        private GameObject _user;

        public void Initialize(GameObject user)
        {
            _user = user;
            ability.Initialize(_user, this);
        }

        public void UseAbility(Action callback)
        {
            ability.Use(callback);
        }

        public void ChangeAbility(Ability newAbility)
        {
            ability = newAbility;
            ability.Initialize(_user, this);
        }

        public Ability GetAbility()
        {
            return ability;
        }

        public AbilitySlotEnum GetSlotType()
        {
            return slotType;
        }

        public AnimationClip GetDefaultAnimation()
        {
            return defaultAnimation;
        }
    }
}