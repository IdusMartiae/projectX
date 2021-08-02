using System;
using System.Collections;
using System.Collections.Generic;
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
        
        public override void AcquireTargets(GameObject caster, Action<IEnumerable<GameObject>> callback)
        {
            _characterAbilities.StartCoroutine(AcquireTargetsShape(callback));
        }

        public override void InitializeTargeting(GameObject caster)
        {
            _hitBox = Instantiate(hitBox, caster.transform);
            _hitBox.gameObject.SetActive(false);

            _characterAbilities = caster.GetComponent<CharacterAbilities>();
        }

        private IEnumerator AcquireTargetsShape(Action<IEnumerable<GameObject>> callback)
        {
            _hitBox.gameObject.SetActive(true);
            yield return null;
            
            callback(_hitBox.Targets);
            yield return null;
            
            _hitBox.gameObject.SetActive(false);
        }
        
    }
}