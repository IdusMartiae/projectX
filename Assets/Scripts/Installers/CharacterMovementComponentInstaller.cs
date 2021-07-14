using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CharacterMovementComponentInstaller : MonoInstaller
    {
        [SerializeField] private Transform player;
        [SerializeField] private CharacterMovementSettings movementSettings;
    
        public override void InstallBindings()
        {
            Container.BindInstance(player).WhenInjectedInto<CharacterMovementComponent>();
            Container.BindInstance(player.GetComponent<CharacterController>())
                .WhenInjectedInto<CharacterMovementComponent>();
            Container.BindInstance(movementSettings);
            Container.Bind<CharacterMovementComponent>().AsSingle();
        }
    }
}