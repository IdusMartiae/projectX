using Cinemachine;
using UnityEngine;
using Zenject;

public class VirtualCamera : MonoBehaviour
{
    private Transform _playerTransform;

    [Inject]
    private void Construct(Player player)
    {
        _playerTransform = player.gameObject.transform;
    }

    private void Start()
    {
        var cinemachineVCam = GetComponent<CinemachineVirtualCamera>();
        cinemachineVCam.Follow = _playerTransform;
        cinemachineVCam.LookAt = _playerTransform;
    }
}
