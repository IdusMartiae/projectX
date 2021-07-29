using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public static class MouseToWorldConverter
    {
        private static readonly Camera Camera;
        private static Plane _plane;
        private static float _distance;

        static MouseToWorldConverter()
        {
            Camera = Camera.main;
            _plane = new Plane(Vector3.up, Vector3.zero);
        }

        public static Vector3 GetWorldCoordinates(Vector3 screenPoint)
        {
            var ray = Camera.ScreenPointToRay(screenPoint);
            _plane.Raycast(ray, out _distance);

            return ray.GetPoint(_distance);
        }
    }
}