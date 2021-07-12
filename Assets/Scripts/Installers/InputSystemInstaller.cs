using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputSystemInstaller : MonoInstaller
    {
        [SerializeField] private KeyBindings keyBindings;
        [SerializeField] private InputSystem inputSystem;

        public override void InstallBindings()
        {
            Container.BindInstance(inputSystem).AsSingle();
            Container.BindInstance(keyBindings);
        }
    }
}