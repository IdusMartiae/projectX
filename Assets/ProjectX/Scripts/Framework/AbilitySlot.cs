using System;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class AbilitySlot
    {
        private readonly GameObject _user;
        private IAbility _ability;

        public AbilitySlot(GameObject user, IAbility ability)
        {
            _ability = ability;
            _user = user;

            _ability.Initialize(_user);
        }

        public void UseAbility(Action<AbilityPhase> callback)
        {
            _ability.Use(callback);
        }

        public void ChangeAbility(IAbility newAbility)
        {
            _ability = newAbility;
            _ability.Initialize(_user);
        }

        public Ability GetAbility()
        {
            return (Ability) _ability;
        }
    }
}