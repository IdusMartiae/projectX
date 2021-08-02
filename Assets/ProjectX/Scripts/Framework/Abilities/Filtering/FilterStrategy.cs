using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Filtering
{
    public abstract class FilterStrategy : ScriptableObject
    {
        [SerializeField] protected bool includeFiltered = true;
        public abstract IEnumerable<GameObject> Filter(IEnumerable<GameObject> targets);
    }
}