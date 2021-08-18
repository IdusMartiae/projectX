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
                InitializeTargeting(data.User);
            }
            
            data.UserAbilitiesComponent.StartCoroutine(AcquireTargetsShape(data, callback));
        }

        private void InitializeTargeting(GameObject user)
        {
            _aim = Instantiate(aimPrefab, user.transform);
            _aim.SetActive(false);
            
            _hitBox = Instantiate(hitBoxPrefab, user.transform);
            _hitBox.gameObject.SetActive(false);
        }
        
        private IEnumerator AcquireTargetsShape(AbilityData data, Action callback)
        {
            _aim.SetActive(true);
            while (InputSystem.GetKey(data.SlotType))
            {
                _aim.transform.position = MouseWorldPosition.GetCoordinates();
                yield return null;
            }
            
            _aim.SetActive(false);
            _hitBox.gameObject.SetActive(true);
            _hitBox.transform.position = _aim.transform.position;
            yield return null;

            data.Targets = _hitBox.Targets;
            callback();
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
        }
    }
}