using System;
using System.Collections;
using System.Collections.Generic;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Player.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "targeting_directional_shape", menuName = "Abilities/Targeting/Directional Custom Shape")]
    public class DirectionalShapeTargeting : Targeting
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private HitBox hitBox;
        
        private HitBox _hitBox;
        private PlayerAbilities _playerAbilities;
        
        public override void AcquireTargets(GameObject caster, Action<IEnumerable<GameObject>> callback)
        {
            _playerAbilities.StartCoroutine(AcquireTargetsShape(callback));
        }

        public override void InitializeTargeting(GameObject caster)
        {
            Debug.Log("This");
            _hitBox = Instantiate(hitBox, caster.transform);
            _hitBox.gameObject.SetActive(false);
            
            _hitBox.LayerMask = layerMask;
            _playerAbilities = caster.GetComponent<PlayerAbilities>();
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