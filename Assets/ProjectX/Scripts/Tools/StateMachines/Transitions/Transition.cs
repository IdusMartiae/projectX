using ProjectX.Scripts.Tools.StateMachines.Decisions;
using ProjectX.Scripts.Tools.StateMachines.States;

namespace ProjectX.Scripts.Tools.StateMachines.Transitions
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