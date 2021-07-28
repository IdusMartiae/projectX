using System;
using System.Collections.Generic;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.SettingsSource;
using ProjectX.Scripts.Tools.Wrappers;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
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
    
        public event Action<SlotType> SlotDown;
        public event Action<SlotType> SlotUp;

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
            CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyUp, SlotUp);

            // Return from method if there isn't any keys pressed
            if (!Input.anyKeyDown) return;
            CheckActionsByInputMethod(_keyBindings.Combat, Input.GetKeyDown, SlotDown);
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
            var phase = inputMethod == Input.GetKeyUp ? InputPhase.Up : InputPhase.Down;
        
            foreach (var axisButton in axisButtons)
            {
                if (inputMethod(axisButton.MainKey) || inputMethod(axisButton.AlternativeKey))
                {
                    axis += (int)phase * _axisFloats[axisButton.KeyAction];
                }
            }
        }

    }
}