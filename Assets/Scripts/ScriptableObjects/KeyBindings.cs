using System.Collections.Generic;
using Enums;
using UnityEngine;
using Wrappers;

namespace ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "KeyBindings", menuName = "Scriptable Objects/Key Bindings")]
    public class KeyBindings : ScriptableObject
    {
        [SerializeField] private List<KeyBindingWrapper<PlayerMovementEnum>> movement;
        [SerializeField] private List<KeyBindingWrapper<PlayerCombatEnum>> combat;

        public List<KeyBindingWrapper<PlayerMovementEnum>> Movement => movement;

        public List<KeyBindingWrapper<PlayerCombatEnum>> Combat => combat;
    }
}
