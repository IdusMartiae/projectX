using System.Collections.Generic;
using System.Linq;
using StateMachines.Transitions;

namespace StateMachines.States
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
            foreach (var transition in _transitions.Where(transition => transition.IsTransitionNeeded()))
            {
                return transition.TransitionState;
            }

            return this;
        }
    }
}