using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools.SettingsSource;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerLocomotionSettings locomotionSettings;
        [SerializeField] private string speedParameterName;
        
        private Animator _animator;
        private AnimatorOverrideController _animatorOverrideController;
        private InputSystem _inputSystem;
        private int _movementSpeed;

        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            _animator.runtimeAnimatorController = _animatorOverrideController;
            
            _movementSpeed = Animator.StringToHash(speedParameterName);
        }

        private void Update()
        {
            var velocity = _inputSystem.MovementDirection.magnitude * locomotionSettings.MovementSpeed;
            _animator.SetFloat(_movementSpeed, velocity, 0.1f, Time.deltaTime);
        }
    }
}