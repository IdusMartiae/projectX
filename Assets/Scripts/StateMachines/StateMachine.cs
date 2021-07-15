using StateMachines.States;

namespace StateMachines
{
    public class StateMachine
    {
        private BaseState _currentState;

        public StateMachine(BaseState startingState)
        {
            startingState.OnStateEnter();
            _currentState = startingState;
        }
    
        public void Update()
        {
            var nextState = _currentState.CheckTransitions();
        
            if (_currentState != nextState)
            {
                ChangeState(nextState);
            }
        
            _currentState.Update();
        }

        private void ChangeState(BaseState nextState)
        {
            _currentState.OnStateExit();
            nextState.OnStateEnter();
            _currentState = nextState;
        }
    }
}