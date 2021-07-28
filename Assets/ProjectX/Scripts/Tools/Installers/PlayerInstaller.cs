using Cinemachine;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Tools.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private CinemachineVirtualCamera sceneVirtualCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<Player.Player>().FromComponentInNewPrefab(playerPrefab).AsSingle();
            Container.Bind<ICinemachineCamera>().FromInstance(sceneVirtualCamera);
        }

        public void Awake()
        {
            Container.Instantiate<CameraFocus>();
        }
    }
}