using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 50;
    
    private CharacterController _controller;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _aimPositionAction;
    private InputAction _aimTriggerAction;
    private Quaternion _rotation;
    private Vector2 _cachedInput = Vector2.zero;
    private Vector3 _cachedMove = Vector3.zero;
    private Vector2 _screenMiddlePoint;

    public bool isPressed;
    
    private void Start()
    {
        InitializeComponents();
        _moveAction = _playerInput.actions["Move"];
        _aimPositionAction = _playerInput.actions["AimPosition"];
        _aimTriggerAction = _playerInput.actions["AimTrigger"];

        _screenMiddlePoint.Set(Screen.width / 2f, Screen.height / 2f);
        _rotation = GetRotationAngle(Camera.main);

        _aimTriggerAction.performed += context => isPressed = !isPressed;
        _aimTriggerAction.canceled += context => isPressed = false;
    }

    private void Update()
    {
        if (isPressed)
        {
            var newVector = _aimPositionAction.ReadValue<Vector2>() - _screenMiddlePoint;
            var a = new Vector3(newVector.x, 0, newVector.y); 
            transform.forward = Vector3.MoveTowards(transform.forward,
                _rotation * a,
             Time.deltaTime * rotationSpeed);
        }

        UpdateCachedValues();
        _controller.Move(_cachedMove * (Time.deltaTime * playerSpeed));
        transform.forward = Vector3.MoveTowards(transform.forward,
            _cachedMove.Equals(Vector3.zero) ? transform.forward : _cachedMove.normalized,
            //_cachedMove.normalized,
            Time.deltaTime * rotationSpeed);



        Debug.DrawRay(transform.position, transform.forward, Color.green, Time.deltaTime, true);
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
