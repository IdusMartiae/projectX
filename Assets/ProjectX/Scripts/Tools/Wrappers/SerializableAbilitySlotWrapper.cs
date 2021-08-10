using System;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Tools.Wrappers
{
    [Serializable]
    public struct SerializableAbilitySlotWrapper
    {
        public string elementName;
        [SerializeField] private AbilitySlotEnum slotEnum;
        [SerializeField] private Ability ability;

        public AbilitySlotEnum SlotEnum => slotEnum;
        public Ability Ability => ability;
    }
}