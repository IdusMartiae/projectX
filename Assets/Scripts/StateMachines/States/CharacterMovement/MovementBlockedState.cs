using UnityEngine;

namespace StateMachines.States.CharacterMovement
{
    public class MovementBlockedState : BaseState
    {
        private Animator _animator;
        private static readonly int Moving = Animator.StringToHash("Moving");
        
        public MovementBlockedState(Animator animator)
        {
            _animator = animator;
        }
        
        public override void Update()
        {
            _animator.SetFloat(Moving, 0, 0.1f, Time.deltaTime);
        }
    }
}