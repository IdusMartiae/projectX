using System;
using System.Collections.Generic;
using Enums;
using ScriptableObjects;
using UnityEngine;
using Wrappers;
using Zenject;

public class InputSystem : MonoBehaviour
{
    private KeyBindings _keyBindings;
    private Quaternion _worldRotation;
    private Vector3 _movementDirection = Vector3.zero;
    private Dictionary<MovementDirectionType, Vector3> _movementVectors;

    private Camera _camera;
    private Plane _plane;
    private float distance = 0f;

    public Vector3 MovementDirection => _worldRotation * _movementDirection.normalized;
    public Vector3 MousePosition => GetMouseWorldPosition();
    public event Action<AbilitySlotType> AbilityStarted;
    public event Action<AbilitySlotType> AbilityFinished;

    [Inject]
    private void Construct(KeyBindings keyBindings)
    {
        _keyBindings = keyBindings;
    }

    private void Start()
    {
        _camera = Camera.main;
        _plane = new Plane(Vector3.up, transform.position);
        _worldRotation = GetWorldRotation();
        _movementVectors = GetMovementVectors();
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyDown, AbilityStarted);
            CheckMovementByInputMethod(Input.GetKeyDown);
        }

        CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyUp, AbilityFinished);
        CheckMovementByInputMethod(Input.GetKeyUp);
    }

    private void CheckActionsByInputMethod<T1>(IEnumerable<KeyBindingWrapper<T1>> actionsList,
        Predicate<KeyCode> inputMethod, Action<T1> callback)
    {
        foreach (var action in actionsList)
        {
            if (inputMethod(action.MainKey) || inputMethod(action.AlternativeKey))
            {
                callback?.Invoke(action.KeyAction);
            }
        }
    }

    private void CheckMovementByInputMethod(Predicate<KeyCode> inputMethod)
    {
        var phase = inputMethod == Input.GetKeyDown ? InputPhaseType.Down : InputPhaseType.Up;

        foreach (var movement in _keyBindings.Movement)
        {
            if (inputMethod(movement.MainKey) || inputMethod(movement.AlternativeKey))
            {
                _movementDirection += (int) phase * _movementVectors[movement.KeyAction];
            }
        }
    }

    private Quaternion GetWorldRotation()
    {
        var cameraForward = _camera.transform.forward.normalized;
        var playerForward = transform.forward;

        cameraForward.y = 0;

        return Quaternion.FromToRotation(playerForward, cameraForward);
    }

    private Dictionary<MovementDirectionType, Vector3> GetMovementVectors()
    {
        var dictionary = new Dictionary<MovementDirectionType, Vector3>
        {
            {MovementDirectionType.Forward, Vector3.forward},
            {MovementDirectionType.Back, Vector3.back},
            {MovementDirectionType.Left, Vector3.left},
            {MovementDirectionType.Right, Vector3.right}
        };

        return dictionary;
    }

    private Vector3 GetMouseWorldPosition()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out distance);

        return ray.GetPoint(distance);
    }
}