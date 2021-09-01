using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_directional_linear", menuName = "Abilities/Targeting/Directional Linear")]
    public class DirectionalLinearTargeting : TargetingStrategy
    {
        [SerializeField] private float width;
        [SerializeField] private float range;
        
        private const float Height = 10f;
        private Vector3 _boxHalfExtends = Vector3.zero;
        
        public override void AcquireTargets(AbilityData data, Action callback)
        {
            if (_boxHalfExtends.Equals(Vector3.zero))
            {
                _boxHalfExtends = new Vector3(width, Height, 0.1f) / 2;
            }
            
            data.StartCoroutine(AcquireTargetsLinear(data, callback));
        }

        
        private IEnumerator AcquireTargetsLinear(AbilityData data, Action callback)
        {
            data.TargetedPoint = MouseWorldPosition.GetCoordinates();
            
            var position = data.User.transform.position;
            
            data.Targets = GetTargetObjects(Physics.BoxCastAll(position, _boxHalfExtends,
                data.TargetedPoint - position, Quaternion.identity, range));
            yield return null;
            
            callback();
        }
        
        private IEnumerable<GameObject> GetTargetObjects(IEnumerable<RaycastHit> targets)
        {
            return targets.Select(target => target.collider.gameObject);
        }
        
    }
}