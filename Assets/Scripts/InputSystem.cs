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
    private GlobalRotation _globalRotation;
    private MouseToWorldConverter _mouseToWorldConverter;
    private AxisToMovementConverter _axisToMovementConverter;
    
    private float _verticalAxis;
    private float _horizontalAxis;
    private readonly Dictionary<AxisButtonType, float> _axisFloats = new Dictionary<AxisButtonType, float>
    {
        {
            AxisButtonType.Positive, 1.0f
        },
        {
            AxisButtonType.Negative, -1.0f
        }
    };

    public Vector3 MovementDirection =>
        _globalRotation.WorldRotation *
        _axisToMovementConverter.GetMovementDirection(
            _horizontalAxis,
            _verticalAxis);
    public Vector3 MousePosition => _mouseToWorldConverter.GetWorldCoordinates(Input.mousePosition);
    
    public event Action<AbilitySlotType> AbilitySlotPressed;
    public event Action<AbilitySlotType> AbilitySlotReleased;

    [Inject]
    private void Construct(KeyBindings keyBindings)
    {
        _keyBindings = keyBindings;
    }

    private void Start()
    {
        var mainCamera = Camera.main;
        var player = transform;
        
        _mouseToWorldConverter = new MouseToWorldConverter(mainCamera, player);
        _globalRotation = new GlobalRotation(mainCamera!.transform, player);
        _axisToMovementConverter = new AxisToMovementConverter();
    }

    public void Update()
    {
        CheckAxisByInputMethod(_keyBindings.MovementHorizontalAxis, Input.GetKeyUp, ref _horizontalAxis);
        CheckAxisByInputMethod(_keyBindings.MovementVerticalAxis, Input.GetKeyUp, ref _verticalAxis);
        CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyUp, AbilitySlotReleased);

        // Return from method if there isn't any keys pressed
        if (!Input.anyKeyDown) return;
        CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyDown, AbilitySlotPressed);
        CheckAxisByInputMethod(_keyBindings.MovementHorizontalAxis, Input.GetKeyDown, ref _horizontalAxis);
        CheckAxisByInputMethod(_keyBindings.MovementVerticalAxis, Input.GetKeyDown, ref _verticalAxis);
    }

    private void CheckActionsByInputMethod<T1>(
        IEnumerable<KeyBindingWrapper<T1>> actionsList,
        Predicate<KeyCode> inputMethod, 
        Action<T1> callback)
    {
        foreach (var action in actionsList)
        {
            if (inputMethod(action.MainKey) || inputMethod(action.AlternativeKey))
            {
                callback?.Invoke(action.KeyAction);
            }
        }
    }

    private void CheckAxisByInputMethod(
        IEnumerable<KeyBindingWrapper<AxisButtonType>> axisButtons,
        Predicate<KeyCode> inputMethod,
        ref float axis)
    {
        var phase = inputMethod == Input.GetKeyUp ? InputPhaseType.Up : InputPhaseType.Down;
        
        foreach (var axisButton in axisButtons)
        {
            if (inputMethod(axisButton.MainKey) || inputMethod(axisButton.AlternativeKey))
            {
                axis += (int)phase * _axisFloats[axisButton.KeyAction];
            }
        }
    }

}