using UnityEngine;

namespace StateMachines.States.CharacterMovement
{
    public class MovementBlockedState : BaseState
    {
        private readonly Animator _animator;
        private static readonly int MovementSpeed = Animator.StringToHash("MovementSpeed");
        
        public MovementBlockedState(Animator animator)
        {
            _animator = animator;
        }
        
        public override void Update()
        {
            _animator.SetFloat(MovementSpeed, 0, 0.1f, Time.deltaTime);
        }
    }
}