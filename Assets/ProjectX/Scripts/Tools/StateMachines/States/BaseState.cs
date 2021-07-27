using System.Collections.Generic;
using ProjectX.Scripts.Tools.StateMachines.Transitions;

namespace ProjectX.Scripts.Tools.StateMachines.States
{
    public abstract class BaseState
    {
        private readonly List<Transition> _transitions = new List<Transition>();
        
        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        public virtual void OnStateEnter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnStateExit()
        {
        }

        public BaseState CheckTransitions()
        {
            foreach (var transition in _transitions)
            {
                var nextState = transition.GetNextState();
                if ( nextState != this)
                {
                    return nextState;
                }
                
            }

            return this;
        }
    }
}