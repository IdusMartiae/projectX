using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.Wrappers;
using UnityEngine;

namespace ProjectX.Scripts.Tools.SettingsSource
{
    
    [CreateAssetMenu(fileName = "settings_key_bindings", menuName = "Settings/Key Bindings")]
    public class KeyBindings : ScriptableObject
    {
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementVerticalAxis;
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementHorizontalAxis;
        [SerializeField] private List<KeyBindingWrapper<AbilitySlotEnum>> combat;

        public List<KeyBindingWrapper<AxisButtonType>> MovementVerticalAxis => movementVerticalAxis;
        public List<KeyBindingWrapper<AxisButtonType>> MovementHorizontalAxis => movementHorizontalAxis;
        public List<KeyBindingWrapper<AbilitySlotEnum>> Combat => combat;
    }
}
