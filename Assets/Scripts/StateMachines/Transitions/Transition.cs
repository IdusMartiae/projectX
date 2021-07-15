using StateMachines.Decisions;
using StateMachines.States;

namespace StateMachines.Transitions
{
    public class Transition
    {
        private readonly BaseDecision _decision;
        
        public BaseState TransitionState { get; }

        public Transition(BaseState transitionState, BaseDecision decision)
        {
            TransitionState = transitionState;
            _decision = decision;
        }

        public bool IsTransitionNeeded()
        {
            return _decision.Decide();
        }
    }
}