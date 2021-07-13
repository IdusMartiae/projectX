using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
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
    }
}