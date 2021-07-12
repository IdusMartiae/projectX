using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float playerSpeed = 10f;

    private InputSystem _inputSystem;

    [Inject]
    private void Initialize(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    private void Start()
    {
    }
    
    private void Update()
    {
        
        MovePlayer();
    }

    private void MovePlayer()
    {
        characterController.Move(_inputSystem.MovementDirection * (Time.deltaTime * playerSpeed));
    }
}
