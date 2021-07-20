using ScriptableObjects;
using UnityEngine;

namespace StateMachines.States.CharacterMovement
{
    public class MovingState : BaseState
    {
        private readonly CharacterController _controller;
        private readonly CharacterMovementSettings _movementSettings;
        private readonly InputSystem _inputSystem;
        private readonly Animator _animator;
        private static readonly int MovementSpeed = Animator.StringToHash("MovementSpeed");

        public MovingState(
            CharacterController controller,
            CharacterMovementSettings movementSettings,
            InputSystem inputSystem,
            Animator animator)
        {
            _controller = controller;
            _movementSettings = movementSettings;
            _inputSystem = inputSystem;
            _animator = animator;
        }

        public override void Update()
        {
            _animator.SetFloat(MovementSpeed, _movementSettings.Speed, 0.1f, Time.deltaTime);
            _controller.Move(_inputSystem.MovementDirection * (Time.deltaTime * _movementSettings.Speed));
        }

    }
}