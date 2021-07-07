using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Quaternion _rotation;
    private Vector2 _cachedInput = Vector2.zero;
    private Vector3 _cachedMove = Vector3.zero;

    private void Start()
    {
        InitializeComponents();
        _moveAction = _playerInput.actions["Move"];
        _rotation = GetRotationAngle(Camera.main);
    }
    
    private void Update()
    {
        UpdateCachedValues();
        _controller.Move(_cachedMove * (Time.deltaTime * playerSpeed));
    }

    private void InitializeComponents()
    {
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }
    
    private Quaternion GetRotationAngle(Component mainCamera)
    {
        var cameraForward = mainCamera.transform.forward.normalized;
        var playerForward = transform.forward.normalized;
        cameraForward.y = 0;
        
        return Quaternion.FromToRotation(playerForward, cameraForward);
    }

    private void UpdateCachedValues()
    {
        _cachedInput = _moveAction.ReadValue<Vector2>();
        _cachedMove.Set(_cachedInput.x, 0, _cachedInput.y);
        _cachedMove = _rotation * _cachedMove;
    }
}
