using System;
using System.Collections.Generic;
using ProjectX.Scripts.Tools.Enums;
using UnityEditor;
using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities.Effects
{
    [CreateAssetMenu(fileName = "effect_health", menuName = "Abilities/Effects/Health")]
    public class HealthEffect : EffectStrategy
    {
        [SerializeField] private EffectTypes effect;
        private float _healthChange;
        private Units _units;
        private PercentageType _percentageType;

        public override void ApplyEffect(GameObject caster, IEnumerable<GameObject> targets, Action callback)
        {
            foreach (var target in targets)
            {
                var healthComponent = (CharacterHealth) target.GetComponent(typeof(CharacterHealth));
                if (healthComponent == null) continue;
                
                switch (effect)
                {
                    case EffectTypes.Damage:
                        if (_units == Units.Percent)
                        {
                            healthComponent.TakeDamage(_healthChange, _percentageType);
                        }
                        else
                        {
                            healthComponent.TakeDamage(_healthChange);
                        }
                        break;
                    case EffectTypes.Heal:
                        if (_units == Units.Percent)
                        {
                            healthComponent.Heal(_healthChange, _percentageType);
                        }
                        else
                        {
                            healthComponent.Heal(_healthChange);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [CustomEditor(typeof(HealthEffect))]
        [CanEditMultipleObjects]
        public class HealthEffectEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                var healthEffect = (HealthEffect) target;

                EditorGUILayout.BeginHorizontal();
                
                healthEffect._healthChange = EditorGUILayout.FloatField("Health Change", healthEffect._healthChange);
                healthEffect._units = (Units) EditorGUILayout.EnumPopup(healthEffect._units, GUILayout.MaxWidth(100f));
                
                EditorGUILayout.EndHorizontal();

                if (healthEffect._units == Units.Percent)
                {
                    healthEffect._percentageType =
                        (PercentageType) EditorGUILayout.EnumPopup("Percentage", healthEffect._percentageType);

                }
                else
                {
                }
            }
        }
    }

    public enum EffectTypes
    {
        Heal,
        Damage
    }

    public enum Units
    {
        Points,
        Percent
    }
}