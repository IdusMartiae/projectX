using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public class AxisToMovementConverter
    {
        private Vector3 _movementDirection;
    
        public Vector3 GetMovementDirection(float horizontalAxis, float verticalAxis)
        {
            _movementDirection.Set( horizontalAxis, 0,verticalAxis);
            _movementDirection = _movementDirection.normalized;
        
            return _movementDirection;
        }
    }
}