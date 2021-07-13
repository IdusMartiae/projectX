using System;
using UnityEngine;

namespace Wrappers
{
    [Serializable]
    public class KeyBindingWrapper<T>
    {
        public string name;
        
        [SerializeField] private T keyAction;
        [SerializeField] private KeyCode mainKey;
        [SerializeField] private KeyCode alternativeKey = KeyCode.None;
        
        public T KeyAction => keyAction;
        
        public KeyCode MainKey => mainKey;

        public KeyCode AlternativeKey => alternativeKey;
    }
}