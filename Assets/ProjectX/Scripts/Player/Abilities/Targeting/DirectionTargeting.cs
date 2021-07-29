using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Player.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_direction", menuName = "Abilities/Targeting/Directional")]
    public class DirectionTargeting : Targeting
    {
        [SerializeField] private Collider hitBoxPrefab;

        private Collider hitBoxInstance;
            
        public override void AcquireTargets(GameObject caster, Action<IEnumerable<GameObject>> callback)
        {
            Debug.Log("This is a directional targeting");
        }

        public override void InitializeTargeting(GameObject caster)
        {
            hitBoxInstance = Instantiate(hitBoxPrefab, caster.transform);
            hitBoxInstance.enabled = false;
        }
        
        //private IEnumerator AcuireTargersDirectional()
    }
}