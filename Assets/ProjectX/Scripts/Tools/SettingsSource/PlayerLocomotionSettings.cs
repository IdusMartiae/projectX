using UnityEngine;

namespace ProjectX.Scripts.Tools.SettingsSource
{
    [CreateAssetMenu(fileName = "settings_player_locomotion", menuName = "Scriptable Objects/Player Locomotion Settings")]
    public class PlayerLocomotionSettings : ScriptableObject
    {
        [SerializeField] private float movementSpeed = 5.0f;
        [SerializeField] private float angularVelocity = 5.0f;

        public float MovementSpeed => movementSpeed;
        public float AngularVelocity => angularVelocity;
    }
}