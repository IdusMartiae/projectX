using StateMachines.Decisions;
using StateMachines.States;

namespace StateMachines.Transitions
{
    public class Transition
    {
        private readonly BaseDecision _decision;
        private readonly BaseState _trueState;
        private readonly BaseState _falseState;

        public Transition(BaseState trueState, BaseState falseState, BaseDecision decision)
        {
            _trueState = trueState;
            _falseState = falseState;
            _decision = decision;
        }

        public BaseState GetNextState()
        {
            return _decision.Decide() ? _trueState : _falseState;
        }
    }
}