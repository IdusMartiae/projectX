using System;
using System.Collections;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_location_shape", menuName = "Abilities/Targeting/Location Custom Shape")]
    public class LocationShapeTargeting : TargetingStrategy
    {
        [SerializeField] private GameObject aimPrefab;
        [SerializeField] private HitBox hitBoxPrefab;

        private HitBox _hitBox;
        private GameObject _aim;
        
        public override void AcquireTargets(AbilityData data, Action callback)
        {
            if (_aim == null)
            {
                InitializeTargeting();
            }
            
            data.StartCoroutine(AcquireTargetsShape(data, callback));
        }

        private void InitializeTargeting()
        {
            _aim = Instantiate(aimPrefab);
            _aim.SetActive(false);
            
            _hitBox = Instantiate(hitBoxPrefab);
            _hitBox.gameObject.SetActive(false);
        }
        
        private IEnumerator AcquireTargetsShape(AbilityData data, Action callback)
        {
            _aim.SetActive(true);
            while (InputSystem.GetKey(data.AbilitySlot.GetSlotType()))
            {
                _aim.transform.position = MouseWorldPosition.GetCoordinates();
                yield return null;
            }
            
            data.TargetedPoint = _aim.transform.position;
            
            _aim.SetActive(false);
            _hitBox.gameObject.SetActive(true);
            _hitBox.transform.position = data.TargetedPoint;
            yield return null;

            data.Targets = _hitBox.Targets;
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
            callback();
        }
    }
}