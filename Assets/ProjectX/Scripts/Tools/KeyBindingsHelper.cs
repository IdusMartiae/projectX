using ProjectX.Scripts.Tools.Enums;
using ProjectX.Scripts.Tools.SettingsSource;

namespace ProjectX.Scripts.Tools
{
    /// <summary>
    /// Used to get string names of key bindings.
    /// </summary>
    public static class KeyBindingsHelper
    {
        private static KeyBindings _keyBindings;

        public static void SetKeyBindings(KeyBindings keyBindings)
        {
            _keyBindings = keyBindings;
        }

        /// <summary>
        /// Get string representation of a main key, bound to the ability slot.
        /// </summary>
        /// <param name="slotEnum">ability slot</param>
        /// <param name="useOverride">use overriden names instead of default ones</param>
        /// <returns>
        ///     <para>String name of a main key</para>
        /// </returns>
        public static string GetStringKeyBindingCombatMain(AbilitySlotEnum slotEnum, bool useOverride)
        {
            var stringBinding = _keyBindings.Combat.Find(wrapper => wrapper.KeyAction == slotEnum).MainKey.ToString();
            if (useOverride)
            {
                OverrideKeyString(ref stringBinding);
            }

            return stringBinding;
        }

        /// <summary>
        /// Get string representation of an alternative key, bound to the ability slot.
        /// </summary>
        /// <param name="slotEnum">ability slot</param>
        /// <param name="useOverride">use overriden names instead of default ones</param>
        /// <returns>
        ///     <para>String name of an alternative key</para>
        /// </returns>
        public static string GetStringKeyBindingCombatAlternative(AbilitySlotEnum slotEnum, bool useOverride)
        {
            var stringBinding = _keyBindings.Combat.Find(wrapper => wrapper.KeyAction == slotEnum).AlternativeKey
                .ToString();
            if (useOverride)
            {
                OverrideKeyString(ref stringBinding);
            }

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