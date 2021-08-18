using System;
using System.Collections;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_directional_shape", menuName = "Abilities/Targeting/Directional Custom Shape")]
    public class DirectionalShapeTargeting : TargetingStrategy
    {
        [SerializeField] private HitBox hitBoxPrefab;
        [SerializeField] private float forwardOffset;
        
        private HitBox _hitBox;

        public override void AcquireTargets(AbilityData data, Action callback)
        {
            if (_hitBox == null)
            {
                InitializeTargeting(data.User);
            }
            
            data.StartCoroutine(AcquireTargetsShape(data, callback));
        }

        private void InitializeTargeting(GameObject user)
        {
            _hitBox = Instantiate(hitBoxPrefab, user.transform);
            _hitBox.transform.position += Vector3.forward * forwardOffset;
            
            _hitBox.gameObject.SetActive(false);
        }

        private IEnumerator AcquireTargetsShape(AbilityData data, Action callback)
        {
            data.TargetedPoint = MouseWorldPosition.GetCoordinates();
            
            _hitBox.gameObject.SetActive(true);
            _hitBox.transform.LookAt(data.TargetedPoint);
            yield return null;
            
            data.Targets = _hitBox.Targets;
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
            callback();
        }
        
    }
}