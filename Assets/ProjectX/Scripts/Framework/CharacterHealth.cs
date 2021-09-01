using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHealth;
        
        // TODO REMOVE AFTER DEBUGGING
        // ----------------------------
        public float CurrentHealth => _currentHealth;

        public float MaxHealth => maxHealth;
        // ----------------------------

        public void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float health)
        {
            _currentHealth = Mathf.Max(_currentHealth - health, 0);
        }

        public void TakeDamage(float percent, PercentageType percentageType)
        {
            var health = (percentageType == PercentageType.OfCurrentValue ? _currentHealth : maxHealth) *
                     (percent / 100f);
            _currentHealth = Mathf.Max(_currentHealth - health, 0);
        }
        
        public void Heal(float health)
        {
            _currentHealth = Mathf.Min(_currentHealth + health, maxHealth);
        }

        public void Heal(float percent, PercentageType percentageType)
        {
            var health = (percentageType == PercentageType.OfCurrentValue ? _currentHealth : maxHealth) *
                         (percent / 100f);
            _currentHealth = Mathf.Min(_currentHealth + health, maxHealth);
        }
        
        // TODO: Can later replace this with event, firing when needed for optimization purposes
        public float GetCurrentHealthPercent()
        {
            return _currentHealth / maxHealth;
        }
    }
}