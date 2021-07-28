using System.Collections;
using ProjectX.Scripts.Framework;
using ProjectX.Scripts.Tools;
using UnityEditor;
using UnityEngine;

namespace ProjectX.Scripts.Player
{
    [CreateAssetMenu(fileName = "quick_cast_default", menuName = "Skills/Quick Cast")]
    public class QuickCast : BaseSkill
    {
        [SerializeField] private Collider hitBoxPrefab;
        [SerializeField] private bool directional;
        [HideInInspector] public InputSystem inputSystem;
        
        private Collider _hitBoxInstance;
        private bool _onCooldown;

        public bool Directional => directional; 
        
        public override void Use()
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
                    var newForward = (inputSystem.MousePosition - _skillSlot.PlayerTransform.position).normalized;
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
        
    }

    // neat, but I have no need for serializable field as i already inject IS using zenject
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
    }
}

