using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public static class AxisToMovementConverter
    {
        private static Vector3 _movementDirection;

        static AxisToMovementConverter()
        {
            _movementDirection = Vector3.zero;
        }
        
        public static Vector3 GetMovementDirection(float horizontalAxis, float verticalAxis)
        {
            _movementDirection.Set( horizontalAxis, 0,verticalAxis);
            _movementDirection = _movementDirection.normalized;
        
            return _movementDirection;
        }
    }
}