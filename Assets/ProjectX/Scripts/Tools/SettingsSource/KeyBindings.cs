using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.Wrappers;
using UnityEngine;

namespace ProjectX.Scripts.Tools.SettingsSource
{
    
    [CreateAssetMenu(fileName = "settings_key_bindings", menuName = "Scriptable Objects/Key Bindings")]
    public class KeyBindings : ScriptableObject
    {
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementVerticalAxis;
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementHorizontalAxis;
        [SerializeField] private List<KeyBindingWrapper<AbilitySlot>> combat;

        public List<KeyBindingWrapper<AxisButtonType>> MovementVerticalAxis => movementVerticalAxis;
        public List<KeyBindingWrapper<AxisButtonType>> MovementHorizontalAxis => movementHorizontalAxis;
        public List<KeyBindingWrapper<AbilitySlot>> Combat => combat;
    }
}
