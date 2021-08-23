using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public static class MouseWorldPosition
    {
        private static readonly Camera Camera;
        private static Plane _plane;
        private static float _distance;
        
        static MouseWorldPosition()
        {
            Camera = Camera.main;
            _plane = new Plane(Vector3.up, Vector3.zero);
        }

        public static Vector3 GetCoordinates()
        {
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            _plane.Raycast(ray, out _distance);

            return ray.GetPoint(_distance);
        }
    }
}