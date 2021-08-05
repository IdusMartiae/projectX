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
        private CharacterAbilities _characterAbilities;
        
        public override void AcquireTargets(AbilityData data, Action callback)
        {
            if (_hitBox == null)
            {
                InitializeTargeting(data.User);
            }
            
            _characterAbilities.StartCoroutine(AcquireTargetsShape(data, callback));
        }

        private void InitializeTargeting(GameObject user)
        {
            _hitBox = Instantiate(hitBox, user.transform);
            _hitBox.gameObject.SetActive(false);

            _characterAbilities = user.GetComponent<CharacterAbilities>();
        }

        private IEnumerator AcquireTargetsShape(AbilityData data, Action callback)
        {
            _hitBox.gameObject.SetActive(true);
            yield return null;

            data.Targets = _hitBox.Targets;
                
            callback();
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
        }
        
    }
}