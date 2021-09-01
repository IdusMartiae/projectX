using System;
using ProjectX.Scripts.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectX.Scripts.Environment.UI
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private CharacterHealth healthComponent;
        [SerializeField] private Image healthBarFill;
        [SerializeField] private TMP_Text healthPointText;

        private void OnEnable()
        {
            healthComponent.HealthChanged += UpdateUI;
        }

        private void OnDisable()
        {
            healthComponent.HealthChanged -= UpdateUI;
        }

        private void UpdateUI(float healthPoints, float healthPercent, float maxHealth)
        {
            healthBarFill.fillAmount = healthPercent;
            healthPointText.text = $"{healthPoints:F0}/{maxHealth:F0}";
        }
    }
}