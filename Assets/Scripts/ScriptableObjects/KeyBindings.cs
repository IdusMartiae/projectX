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
        [SerializeField] private List<KeyBindingWrapper<MovementDirectionType>> movement;
        [SerializeField] private List<KeyBindingWrapper<AbilitySlotType>> combat;

        public List<KeyBindingWrapper<MovementDirectionType>> Movement => movement;

        public List<KeyBindingWrapper<AbilitySlotType>> Combat => combat;
    }
}
