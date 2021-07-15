using ScriptableObjects;
using UnityEngine;

namespace StateMachines.States.CharacterMovement
{
    public class MovingState : BaseState
    {
        private readonly CharacterController _controller;
        private readonly CharacterMovementSettings _movementSettings;
        private readonly InputSystem _inputSystem;
        
        public MovingState(
            CharacterController controller,
            CharacterMovementSettings movementSettings,
            InputSystem inputSystem)
        {
            _controller = controller;
            _movementSettings = movementSettings;
            _inputSystem = inputSystem;
        }
        
        public override void Update()
        {
            _controller.Move(_inputSystem.MovementDirection * (Time.deltaTime * _movementSettings.Speed));
        }

    }
}