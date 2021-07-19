using System.Collections.Generic;
using Enums;
using UnityEngine;
using Wrappers;

namespace ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "KeyBindings", menuName = "Scriptable Objects/Key Bindings")]
    public class KeyBindings : ScriptableObject
    {
        // TODO REPLACE WITH CONTAINER CLASS
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementVerticalAxis;
        [SerializeField] private List<KeyBindingWrapper<AxisButtonType>>movementHorizontalAxis;
        [SerializeField] private List<KeyBindingWrapper<AbilitySlotType>> combat;

        public List<KeyBindingWrapper<AxisButtonType>> MovementVerticalAxis => movementVerticalAxis;
        public List<KeyBindingWrapper<AxisButtonType>> MovementHorizontalAxis => movementHorizontalAxis;

        public List<KeyBindingWrapper<AbilitySlotType>> Combat => combat;
    }
}
