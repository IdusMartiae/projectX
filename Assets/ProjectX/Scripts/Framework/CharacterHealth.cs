using System;
using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHealth;

        public Action<float, float, float> HealthChanged;
        
        private void Awake()
        {
            HealthChanged = delegate{ };
        }

        public void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float health)
        {
            _currentHealth = Mathf.Max(_currentHealth - health, 0);
            HealthChanged.Invoke(_currentHealth, _currentHealth / maxHealth, maxHealth);
        }

        public void TakeDamage(float percent, PercentageType percentageType)
        {
            var health = (percentageType == PercentageType.OfCurrentValue ? _currentHealth : maxHealth) *
                     (percent / 100f);
            _currentHealth = Mathf.Max(_currentHealth - health, 0);
            HealthChanged.Invoke(_currentHealth, _currentHealth / maxHealth, maxHealth);
        }
        
        public void Heal(float health)
        {
            _currentHealth = Mathf.Min(_currentHealth + health, maxHealth);
            HealthChanged.Invoke(_currentHealth, _currentHealth / maxHealth, maxHealth);
        }

        public void Heal(float percent, PercentageType percentageType)
        {
            var health = (percentageType == PercentageType.OfCurrentValue ? _currentHealth : maxHealth) *
                         (percent / 100f);
            _currentHealth = Mathf.Min(_currentHealth + health, maxHealth);
            HealthChanged.Invoke(_currentHealth, _currentHealth / maxHealth, maxHealth);
        }
    }
}
