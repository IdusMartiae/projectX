using ScriptableObjects;
using UnityEngine;

public class CharacterMovementComponent
{
    private Transform _transform;
    private CharacterController _controller;
    private InputSystem _inputSystem;
    private CharacterMovementSettings _movementSettings;
    
    private CharacterMovementComponent(Transform transform, CharacterController controller, InputSystem inputSystem,
        CharacterMovementSettings movementSettings)
    {
        _transform = transform;
        _controller = controller;
        _inputSystem = inputSystem;
        _movementSettings = movementSettings;
    }
    
    public void Update(bool movementBlocked, bool lookAtMouse)
    {
        if (!movementBlocked)
        {
            _controller.Move(_inputSystem.MovementDirection * (Time.deltaTime * _movementSettings.Speed));
        }
        
        RotateCharacter(lookAtMouse);
    }

    private void RotateCharacter(bool lookAtMouse)
    {
        var lookAtDirection = _inputSystem.MovementDirection;
        
        if (lookAtMouse)
        { 
            lookAtDirection = (_inputSystem.MousePosition - _transform.position).normalized;
            lookAtDirection.y = 0;
        }
        
        _transform.forward = Vector3.RotateTowards(_transform.forward, lookAtDirection,
            Time.deltaTime * _movementSettings.AngularSpeed, 0);
    }
}