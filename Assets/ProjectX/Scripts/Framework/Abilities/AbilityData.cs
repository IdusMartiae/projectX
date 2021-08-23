using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public class AbilityData
    {
        public GameObject User { get; }
        public IEnumerable<GameObject> Targets { get; set; }
        public Vector3 TargetedPoint { get; set; } = Vector3.zero;
        public AbilitySlot AbilitySlot { get; }
        public string TriggerName { get; }

        private readonly MonoBehaviour _monoBehaviour;

        public AbilityData(GameObject user, AbilitySlot abilitySlot)
        {
            User = user;
            _monoBehaviour = user.GetComponent<MonoBehaviour>();
            AbilitySlot = abilitySlot;
            TriggerName = abilitySlot.GetSlotType().ToString();
        }

        public void StartCoroutine(IEnumerator routine)
        {
            _monoBehaviour.StartCoroutine(routine);
        }
    }
}