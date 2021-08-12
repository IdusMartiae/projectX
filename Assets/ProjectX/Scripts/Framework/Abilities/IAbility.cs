using System;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public interface IAbility
    {
        public void Use(Action<AbilityPhase> callback);
        public void Initialize(GameObject user);
    }
}