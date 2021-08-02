using ProjectX.Scripts.Tools.SettingsSource;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterLocomotion : MonoBehaviour
    {
        [SerializeField] private PlayerLocomotionSettings locomotionSettings;
            
        private CharacterController _characterController;
        private InputSystem _inputSystem;

        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _characterController.Move(_inputSystem.MovementDirection *
                                      (locomotionSettings.MovementSpeed * Time.deltaTime));
            transform.forward = Vector3.RotateTowards(transform.forward, _inputSystem.MovementDirection,
                locomotionSettings.AngularVelocity * Time.deltaTime, 0);
        }
    }
}