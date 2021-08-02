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
        
        private Vector3 _boxHalfExtends;
        private CharacterAbilities _characterAbilities;
        
        public override void AcquireTargets(GameObject caster, Action<IEnumerable<GameObject>> callback)
        {
            _characterAbilities.StartCoroutine(AcquireTargetsLinear(caster, callback));
        }

        public override void InitializeTargeting(GameObject caster)
        {
            var casterController = caster.GetComponent<CharacterController>();
            _characterAbilities = caster.GetComponent<CharacterAbilities>();
            _boxHalfExtends = new Vector3(width, casterController.height, 0.1f) / 2;
            
            //Delete after testing
            _characterAbilities.StartCoroutine(DrawHitBox(caster));
        }
        
        private IEnumerator AcquireTargetsLinear(GameObject caster, Action<IEnumerable<GameObject>> callback)
        {
            var targets = Physics.BoxCastAll(
                caster.transform.position, 
                _boxHalfExtends, 
                MouseWorldPosition.GetCoordinates() - caster.transform.position, 
                Quaternion.identity, 
                range);
            
            callback(GetTargetObjects(targets));
            
            yield return null;
        }

        //Delete after testing
        private IEnumerator DrawHitBox(GameObject caster)
        {
            while (true)
            {
                var dir = - caster.transform.position;
                dir.y = 0;
                dir += MouseWorldPosition.GetCoordinates();
                Debug.DrawRay(caster.transform.position, dir.normalized * range);
                yield return null;
            }
        }

        private IEnumerable<GameObject> GetTargetObjects(RaycastHit[] targets)
        {
            return targets.Select(target => target.collider.gameObject);
        }
        
    }
}