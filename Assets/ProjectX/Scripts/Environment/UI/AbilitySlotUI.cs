using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectX.Scripts.Environment.UI
{
    public class AbilitySlotUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text keyBinding;
        [SerializeField] private AbilitySlotType slotType; 
        
        private AbilitySlot _abilitySlot;

        private void Start()
        {
            keyBinding.text = KeyBindingsHelper.GetStringKeyBindingCombatMain(slotType);
        }
        
        public void InitializeAbility(AbilitySlot abilitySlot)
        {
            _abilitySlot = abilitySlot;
            icon.sprite = _abilitySlot.GetAbility().Icon;
        }

        public AbilitySlotType GetSlotType()
        {
            return slotType;
        }
    }
}
