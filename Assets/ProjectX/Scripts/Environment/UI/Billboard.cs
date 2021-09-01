using UnityEngine;

namespace ProjectX.Scripts.Environment.UI
{
    public class Billboard : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _mainCamera.transform.forward);
        }
    }
}