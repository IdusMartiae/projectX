using UnityEngine;

namespace StateMachines.Decisions.MovementDecisions
{
    public class MovementButtonUpDecision : BaseDecision
    {
        private readonly InputSystem _inputSystem;

        public MovementButtonUpDecision(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        public override bool Decide()
        {
            return _inputSystem.MovementDirection == Vector3.zero;
        }
    }
}