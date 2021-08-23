using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools.SettingsSource;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Tools.Installers
{
    public class InputSystemInstaller : MonoInstaller
    {
        [SerializeField] private InputSystem inputSystem;
        [SerializeField] private KeyBindings keyBindings;

        public override void InstallBindings()
        {
            Container.BindInstance(inputSystem).AsSingle();
            Container.BindInstance(keyBindings).AsSingle();
        }

        private void Awake()
        {
            KeyBindingsKeyToStringConverter.SetKeyBindings(keyBindings);
        }
    }
}