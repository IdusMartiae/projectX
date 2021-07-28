using Cinemachine;

namespace ProjectX.Scripts.Tools
{
    public class CameraFocus
    {
        private CameraFocus(ICinemachineCamera virtualCamera, Player.Player player)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
    }
}