using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools;
using ProjectX.Scripts.Tools.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using AbilitySlot = ProjectX.Scripts.Framework.AbilitySlot;

namespace ProjectX.Scripts.Environment.UI
{
    // TODO ABILITY SLOT IS UPDATED ON PLAYER ABILITY COMPONENT EVENT
    public class AbilitySlotUI : MonoBehaviour
    {
        private Image icon;
        private TMP_Text keyBinding;
        private AbilitySlotEnum slotEnum;
        
        private AbilitySlot _abilitySlot;
        private InputSystem _inputSystem;
        
        [Inject]
        private void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            keyBinding.text = KeyBindingsHelper.GetStringKeyBindingCombatMain(slotEnum, true);
        }
        
        // TODO IS THIS THE BEST PLACE TO TRACK INPUT?
        private void Update()
        {
            if (_inputSystem.GetKeyDown(slotEnum))
            {
                _abilitySlot.UseAbility();
            }
        }

        public void SetAbilitySlot(AbilitySlot abilitySlot)
        {
            _abilitySlot = abilitySlot;
            icon.sprite = _abilitySlot.GetAbility().Icon;
        }

        public AbilitySlotEnum GetSlotType()
        {
            return slotEnum;
        }
    }
}
