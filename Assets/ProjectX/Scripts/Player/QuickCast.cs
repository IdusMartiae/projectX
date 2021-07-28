using System.Collections;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Player
{
    [CreateAssetMenu(fileName = "quick_cast_default", menuName = "Skills/Quick Cast")]
    public class QuickCast : BaseSkill
    {
        [SerializeField] private Collider hitBoxPrefab;

        private Collider _hitBoxInstance;
        
        public override void Use()
        {
            
        }

        public override void Cancel()
        {
        }

        public override void Initialize(SkillSlot skillSlot)
        {
            base.Initialize(skillSlot);
            
            _skillSlot.AnimatorOverrideController[_skillSlot.ClipName] = animation;
            
            _hitBoxInstance = Instantiate(hitBoxPrefab, _skillSlot.PlayerTransform);
            _hitBoxInstance.enabled = false;
        }

        public override void Deinitialize()
        {
        }

        private IEnumerator UseQuickCast()
        {
            _skillSlot.Animator.SetTrigger(_skillSlot.TriggerHash);
            _hitBoxInstance.enabled = true;
            yield return null;
            
            _hitBoxInstance.enabled = false;
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldown);
        }
        
    }
}