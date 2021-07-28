using ProjectX.Scripts.Tools.SettingsSource;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerLocomotion : MonoBehaviour
    {
        [SerializeField] private PlayerLocomotionSettings locomotionSettings;
            
        private CharacterController _characterController;
        private Animator _animator;
        private InputSystem _inputSystem;
        private static readonly int MovementSpeed = Animator.StringToHash("Player speed");

        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(MovementSpeed, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
            _characterController.Move(_inputSystem.MovementDirection *
                                      (locomotionSettings.MovementSpeed * Time.deltaTime));
            transform.forward = Vector3.RotateTowards(transform.forward, _inputSystem.MovementDirection,
                locomotionSettings.AngularVelocity * Time.deltaTime, 0);
        }
    }
}