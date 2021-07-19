using UnityEngine;

public class MouseToWorldConverter
{
    private readonly Camera _camera;
    private Plane _plane;
    private float _distance;

    public MouseToWorldConverter(Camera camera, Transform player)
    {
        _camera = camera;
        _plane = new Plane(Vector3.up, player.position);
    }

    public Vector3 GetWorldCoordinates(Vector3 screenPoint)
    {
        var ray = _camera.ScreenPointToRay(screenPoint);
        _plane.Raycast(ray, out _distance);

        return ray.GetPoint(_distance);
    }
}