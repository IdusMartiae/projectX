using System.Collections.Generic;
using ModestTree;
using ProjectX.Scripts.Player.Abilities.Targeting;
using ProjectX.Scripts.Tools;
using UnityEngine;

namespace ProjectX.Scripts.Player
{
    [CreateAssetMenu(fileName = "quick_cast_default", menuName = "Abilities/Quick Cast")]
    public class QuickCast : BaseSkill
    {
        [SerializeField] private Targeting targeting;
        
        private bool _onCooldown;
        
        public override void Use()
        {
            targeting.AcquireTargets(_skillSlot.Animator.gameObject, PrintTargets);
        }


        private void PrintTargets(IEnumerable<GameObject> targetObjects)
        {
            if (targetObjects.IsEmpty())
            {
                Debug.Log("None");
            }
            else
            {
                foreach (var gameObject in targetObjects)
                {
                    Debug.Log(gameObject);
                }
            }
        }

        public override void Initialize(SkillSlot skillSlot)
        {
            base.Initialize(skillSlot);
            targeting.InitializeTargeting(skillSlot.PlayerTransform.gameObject);
        }
        /*public override void Use()
        {
            if (_onCooldown) return;
            _skillSlot.PlayerAbilities.StartCoroutine(UseQuickCast());
            _skillSlot.PlayerAbilities.StartCoroutine(StartCooldown());
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

            _onCooldown = false;
        }

        public override void Deinitialize()
        {
            Destroy(_hitBoxInstance);
        }

        private IEnumerator UseQuickCast()
        {
            _skillSlot.Animator.SetTrigger(_skillSlot.TriggerId);
            _hitBoxInstance.enabled = true;
            yield return null;

            if (directional)
            {
                var activeTime = 0f;
                while (activeTime < duration)
                {
                    var newForward = (_skillSlot.InputSystem.MousePosition - _skillSlot.PlayerTransform.position).normalized;
                    _skillSlot.PlayerTransform.forward = Vector3.RotateTowards(_skillSlot.PlayerTransform.forward,
                        newForward, 0.1f, Time.deltaTime);
                    activeTime += Time.deltaTime;
                }
            }
                
            _hitBoxInstance.enabled = false;
        }

        private IEnumerator StartCooldown()
        {
            _onCooldown = true;
            yield return new WaitForSeconds(cooldown);
            
            _onCooldown = false;
        }
        
    }*/

        /*// neat, but I have no need for serializable field as i already inject IS using zenject
        [CustomEditor(typeof(QuickCast))]
        public class QuickCastEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
    
                var quickCast = target as QuickCast;
                
                if (quickCast.Directional)
                {
                    quickCast.inputSystem = EditorGUILayout.ObjectField("Input System", quickCast.inputSystem, typeof(InputSystem), true) as InputSystem;
                }
            }
        }*/
        public override void Deinitialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
