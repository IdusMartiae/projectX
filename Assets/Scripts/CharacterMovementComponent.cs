using ScriptableObjects;
using UnityEngine;
using Zenject;

public class CharacterMovementComponent : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    
    private InputSystem _inputSystem;
    private CharacterMovementSettings _movementSettings;

    [Inject]
    private void Construct(InputSystem inputSystem, CharacterMovementSettings movementSettings)
    {
        _inputSystem = inputSystem;
        _movementSettings = movementSettings;
    }
    
    private void Update()
    {
        controller.Move(_inputSystem.MovementDirection * (Time.deltaTime * _movementSettings.Speed));
        transform.forward = Vector3.RotateTowards(transform.forward, _inputSystem.MovementDirection,
            Time.deltaTime * _movementSettings.AngularSpeed, 0);
    }
    
}