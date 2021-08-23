using ProjectX.Scripts.Tools.StateMachines.States;

namespace ProjectX.Scripts.Tools.StateMachines
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
        
        public virtual void ChangeState(BaseState nextState)
        {
            _currentState.OnStateExit();
            nextState.OnStateEnter();
            _currentState = nextState;
        }
    }
}