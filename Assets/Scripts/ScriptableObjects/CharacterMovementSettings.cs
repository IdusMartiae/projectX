using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterMovementSettings", menuName = "Scriptable Objects/Character Movement Settings")]
    public class CharacterMovementSettings : ScriptableObject
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float angularSpeed = 5f;

        public float Speed => speed;
        
        public float AngularSpeed => angularSpeed;
    }
}