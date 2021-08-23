using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public static class GlobalRotation
    {
        public static Quaternion WorldRotation { get; private set; }
        
        public static void CalculateGlobalRotation(Vector3 playerForward)
        {
            var cameraForward = Camera.main!.transform.forward;
            cameraForward.y = 0;

            WorldRotation = Quaternion.FromToRotation(playerForward, cameraForward);
        }
    }
}