using ScriptableObjects;
using UnityEngine;

namespace StateMachines.States.CharacterAim
{
    public class FaceForwardState : BaseState
    {
        private readonly Transform _characterTransform;
        private readonly CharacterMovementSettings _movementSettings;
        private readonly InputSystem _inputSystem;
        
        public FaceForwardState(
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
           _characterTransform.forward = Vector3.RotateTowards(
               _characterTransform.forward, 
               _inputSystem.MovementDirection,
               Time.deltaTime * _movementSettings.AngularSpeed,
               0);
        }
    }
}