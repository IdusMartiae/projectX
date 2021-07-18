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
        // TODO: do you need script for that?
        var cinemachineVCam = GetComponent<CinemachineVirtualCamera>();
        cinemachineVCam.Follow = _playerTransform;
        cinemachineVCam.LookAt = _playerTransform;
    }
}
