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
            
            data.UserAbilitiesComponent.StartCoroutine(AcquireTargetsLinear(data, callback));
        }

        
        private IEnumerator AcquireTargetsLinear(AbilityData data, Action callback)
        {
            var position = data.User.transform.position;
            
            data.Targets = GetTargetObjects(Physics.BoxCastAll(position, _boxHalfExtends,
                MouseWorldPosition.GetCoordinates() - position, Quaternion.identity, range));
            
            callback();
            
            yield return null;
        }
        
        private IEnumerable<GameObject> GetTargetObjects(IEnumerable<RaycastHit> targets)
        {
            return targets.Select(target => target.collider.gameObject);
        }
        
    }
}