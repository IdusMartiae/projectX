using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Player;
using UnityEngine;

namespace ProjectX.Scripts.Tools
{
    public class SkillSlot
    {
        private BaseSkill _skill;
        public Transform PlayerTransform { get; }
        public PlayerAbilities PlayerAbilities { get; }
        public Animator Animator { get; }
        public AnimatorOverrideController AnimatorOverrideController { get; }
        public int TriggerId { get; }
        public string ClipName { get; }
        
        public SkillSlot(GameObject player, BaseSkill skill, string triggerName)
        {
            ClipName = triggerName;
            
            PlayerTransform = player.transform;
            PlayerAbilities = player.GetComponent<PlayerAbilities>();
            
            Animator = player.GetComponent<Animator>();
            AnimatorOverrideController = new AnimatorOverrideController(Animator.runtimeAnimatorController);
            Animator.runtimeAnimatorController = AnimatorOverrideController;
            
            TriggerId = Animator.StringToHash(triggerName);
            
            _skill = skill;
            _skill.Initialize(this);
        }
        
        public void UseSkill()
        {
            _skill.Use();
        }

        public void CancelSkill()
        {
            _skill.Cancel();
        }

        public void ChangeSkill(BaseSkill newSkill)
        {
            _skill.Deinitialize();
            _skill = newSkill;
            _skill.Initialize(this);
        }
    }
}