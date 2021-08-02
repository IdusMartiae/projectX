using ProjectX.Scripts.Framework.Abilities;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Framework
{
    public class AbilitySlot
    {
        private IAbility _ability;
        public Transform PlayerTransform { get; }
        public Animator Animator { get; }
        public AnimatorOverrideController AnimatorOverrideController { get; }
        public int TriggerId { get; }
        public string ClipName { get; }

        [Inject] public InputSystem InputSystem { get; }

        public AbilitySlot(GameObject player, IAbility ability, string triggerName)
        {
            ClipName = triggerName;
            
            PlayerTransform = player.transform;
            
            Animator = player.GetComponent<Animator>();
            AnimatorOverrideController = new AnimatorOverrideController(Animator.runtimeAnimatorController);
            Animator.runtimeAnimatorController = AnimatorOverrideController;
            
            TriggerId = Animator.StringToHash(triggerName);
            
            _ability = ability;
            _ability.Initialize(this);
        }
        
        public void UseAbility()
        {
            _ability.Use();
        }

        public void CancelAbility()
        {
            _ability.Cancel();
        }

        public void ChangeAbility(IAbility newAbility)
        {
            _ability.Deinitialize();
            _ability = newAbility;
            _ability.Initialize(this);
        }
    }
}