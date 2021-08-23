using ProjectX.Scripts.Framework.Abilities;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    public class AbilitySlotUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image cooldownMask;
        [SerializeField] private TMP_Text keyBinding;
        [SerializeField] private AbilitySlotEnum slotEnum;

        public AbilitySlotEnum SlotEnum => slotEnum;

        private Ability _ability;
        private CooldownStore _cooldownStore;

        [Inject]
        private void Construct(Player.Player player)
        {
            _cooldownStore = player.GetComponent<CooldownStore>();
        }

        private void Start()
        {
            keyBinding.text = KeyBindingsKeyToStringConverter.GetStringKeyBindingCombatMain(slotEnum, true);
        }

        public void UpdateUI()
        {
            cooldownMask.fillAmount = _cooldownStore.GetPercentageRemaining(_ability);
        }

        private void SetAbilitySlotIcon()
        {
            if (_ability == null)
            {
                return;
            }

            var abilityIcon = _ability.Icon;

            icon.sprite = abilityIcon;
            cooldownMask.sprite = abilityIcon;
        }

        public void SetAbility(Ability ability)
        {
            _ability = ability;
            SetAbilitySlotIcon();
        }
    }
}