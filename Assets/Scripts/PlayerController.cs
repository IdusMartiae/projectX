using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Vector3 _cameraForward;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    void Update()
    {
        var input = _moveAction.ReadValue<Vector2>(); 
        var move = new Vector3(input.x, 0, input.y);
        // TODO FIX MOVEMENT DIRECTION;
        _controller.Move(move * (Time.deltaTime * playerSpeed));
    }
}
