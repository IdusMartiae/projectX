using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Player
{
    public abstract class BaseSkill : ScriptableObject
    {
        [Header("Common")] 
        [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected AnimationClip animation;

        [Header("Parameters")] 
        [SerializeField] protected float duration;
        [SerializeField] protected float cooldown;

        protected SkillSlot _skillSlot;

        public virtual void Use()
        {
        }

        public virtual void Cancel()
        {
        }

        public virtual void Initialize(SkillSlot skillSlot)
        {
            _skillSlot = skillSlot;
        }

        public abstract void Deinitialize();
    }
}