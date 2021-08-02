using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void ApplyEffect(GameObject caster, IEnumerable<GameObject> targets, Action callback);
    }
}