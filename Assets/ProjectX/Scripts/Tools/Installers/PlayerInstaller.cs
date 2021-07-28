using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Tools.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<Player.Player>().FromComponentInNewPrefab(playerPrefab).AsSingle();
        }
    }
}