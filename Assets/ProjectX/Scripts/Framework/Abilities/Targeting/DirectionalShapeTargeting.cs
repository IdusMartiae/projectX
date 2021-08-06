using System;
using System.Collections;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_directional_shape", menuName = "Abilities/Targeting/Directional Custom Shape")]
    public class DirectionalShapeTargeting : TargetingStrategy
    {
        [SerializeField] private HitBox hitBox;
        
        private HitBox _hitBox;

        public override void AcquireTargets(AbilityData data, Action callback)
        {
            if (_hitBox == null)
            {
                InitializeTargeting(data.User);
            }
            
            data.UserAbilitiesComponent.StartCoroutine(AcquireTargetsShape(data, callback));
        }

        private void InitializeTargeting(GameObject user)
        {
            _hitBox = Instantiate(hitBox, user.transform);
        }

        private IEnumerator AcquireTargetsShape(AbilityData data, Action callback)
        {
            _hitBox.gameObject.SetActive(true);
            _hitBox.transform.LookAt(MouseWorldPosition.GetCoordinates());
            yield return null;

            Debug.DrawRay(_hitBox.transform.position, _hitBox.transform.forward * 3f, Color.red, 500f);
            
            data.Targets = _hitBox.Targets;
                
            callback();
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
        }
        
    }
}