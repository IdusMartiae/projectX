using UnityEngine;

namespace StateMachines.Decisions
{
    public class MovementButtonDownDecision : BaseDecision
    {
        private readonly InputSystem _inputSystem;

        public MovementButtonDownDecision(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        public override bool Decide()
        {
            return _inputSystem.MovementDirection != Vector3.zero;
        }
    }
}