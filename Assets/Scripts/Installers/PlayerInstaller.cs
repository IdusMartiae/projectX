using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private CharacterMovementSettings movementSettings;
    
        public override void InstallBindings()
        {
            Container.BindInstance(movementSettings);
            Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle();
        }
    }
}