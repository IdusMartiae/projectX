using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.SettingsSource;

namespace ProjectX.Scripts.Tools
{
    public static class KeyBindingsHelper
    {
        private static KeyBindings _keyBindings;
        
        public static void SetKeyBindings(KeyBindings keyBindings)
        {
            _keyBindings = keyBindings;
        }

        public static string GetStringKeyBindingCombatMain(AbilitySlotType slotType)
        {
            var stringBinding = _keyBindings.Combat.Find(wrapper => wrapper.KeyAction == slotType).MainKey.ToString();
            OverrideKeyString(ref stringBinding);
            
            return stringBinding;
        }

        public static string GetStringKeyBindingCombatAlternative(AbilitySlotType slotType)
        {
            var stringBinding = _keyBindings.Combat.Find(wrapper => wrapper.KeyAction == slotType).AlternativeKey
                .ToString();
            OverrideKeyString(ref stringBinding);
            
            return stringBinding;
        }
        
        private static void OverrideKeyString(ref string keyString)
        {
            keyString = keyString switch
            {
                "Mouse0" => "LMB",
                "Mouse1" => "RMB",
                "None" => "-",
                _ => keyString
            };
        }
    }
}