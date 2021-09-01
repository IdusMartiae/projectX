using System;
using System.Collections;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_spawn_prefab_on_target", menuName = "Abilities/Effects/Spawn Prefab on Target")]
    public class SpawnPrefabOnTargetEffect : EffectStrategy
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float lifetime;
        
        private GameObject _prefabInstance;
        
        public override void ApplyEffect(AbilityData data, Action callback)
        {
            if (_prefabInstance == null)
            {
                _prefabInstance = Instantiate(prefab);
            }
            
            data.StartCoroutine(SpawnPrefab(data));
        }

        private IEnumerator SpawnPrefab(AbilityData data)
        {
            _prefabInstance.SetActive(true);
            _prefabInstance.transform.position = data.TargetedPoint;
            
            if (lifetime > 0)
            {
                yield return new WaitForSeconds(lifetime);
            }
            
            _prefabInstance.SetActive(false);
        }
    }
}