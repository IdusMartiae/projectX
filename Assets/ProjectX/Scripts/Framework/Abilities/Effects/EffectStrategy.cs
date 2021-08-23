using System;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void ApplyEffect(AbilityData data, Action callback);
    }
}