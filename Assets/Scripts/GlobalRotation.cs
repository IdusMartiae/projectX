using UnityEngine;

public class GlobalRotation
{
    public Quaternion WorldRotation { get; }

    public GlobalRotation(Transform camera, Transform player)
    {
        var cameraForward = camera.forward;
        var playerForward = player.forward;
        
        cameraForward.y = 0;
        
        WorldRotation = Quaternion.FromToRotation(playerForward, cameraForward);
    }
}