using ScriptableObjects;
using UnityEngine;

namespace StateMachines.States.CharacterAim
{
    public class LookAtMouseState : BaseState
    {
        private readonly Transform _characterTransform;
        private readonly CharacterMovementSettings _movementSettings;
        private readonly InputSystem _inputSystem;
        
        public LookAtMouseState(
            Transform characterTransform,
            CharacterMovementSettings movementSettings,
            InputSystem inputSystem)
        {
            _characterTransform = characterTransform;
            _movementSettings = movementSettings;
            _inputSystem = inputSystem;
        }
        
        public override void Update()
        {
            var lookAtDirection = (_inputSystem.MousePosition - _characterTransform.position).normalized;
            lookAtDirection.y = 0;
            
            _characterTransform.forward = Vector3.RotateTowards(_characterTransform.forward, lookAtDirection,
                Time.deltaTime * _movementSettings.AngularSpeed, 0);
            
        }
    }
}