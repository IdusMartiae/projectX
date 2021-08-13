using System.Collections;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    // TODO ABILITY SLOT IS UPDATED ON PLAYER ABILITY COMPONENT EVENT
    public class AbilitySlotUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image cooldownMask;
        [SerializeField] private TMP_Text keyBinding;
        [SerializeField] private AbilitySlotEnum slotEnum;

        private AbilitySlot _abilitySlot;
        
        [Inject] private Player.Player _player;
        
        private void Start()
        {
            keyBinding.text = KeyBindingsHelper.GetStringKeyBindingCombatMain(slotEnum, true);
        }

        private void Update()
        {
            cooldownMask.fillAmount = _player
                .GetComponent<CooldownStore>()
                .GetPercentageRemaining(_abilitySlot.GetAbility());;
        }
        
        public void UpdateUI()
        {
            if (_abilitySlot == null) return;
            
            icon.sprite = _abilitySlot.GetAbility().Icon;
            cooldownMask.sprite = _abilitySlot.GetAbility().Icon;
        }

        public void SetAbilitySlot(AbilitySlot abilitySlot)
        {
            _abilitySlot = abilitySlot;
            UpdateUI();
        }

        public AbilitySlotEnum GetSlotType()
        {
            return slotEnum;
        }
        
    }
}