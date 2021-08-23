using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public class HitBox : MonoBehaviour
    {
        private readonly List<GameObject> _targets = new List<GameObject>();

        public List<GameObject> Targets => _targets;
        
        private void OnEnable()
        {
            _targets.Clear();
        }

        private void OnTriggerEnter(Collider target)
        {
            _targets.Add(target.gameObject);
        }
    }
}