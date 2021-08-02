using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    // TODO method basically have the same code, merge where possible
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

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        }

        public void TakeDamagePercentOfMax(float healthPercent)
        {
            healthPercent = Mathf.Clamp01(healthPercent);
            _currentHealth = Mathf.Max(_currentHealth - maxHealth * healthPercent, 0);
        }

        public void TakeDamagePercentOfCurrent(float healthPercent)
        {
            healthPercent = Mathf.Clamp01(healthPercent);
            _currentHealth = Mathf.Max(_currentHealth - _currentHealth * healthPercent, 0);
        }
        
        public void Regenerate(float healthRecovered)
        {
            _currentHealth = Mathf.Min(_currentHealth + healthRecovered, maxHealth);
        }

        public void RegeneratePercentOfMax(float healthRecoveredPercent)
        {
            healthRecoveredPercent = Mathf.Clamp01(healthRecoveredPercent);
            _currentHealth = Mathf.Min(_currentHealth + maxHealth * healthRecoveredPercent, maxHealth);
        }

        public void RegeneratePercentOfCurrent(float healthRecoveredPercent)
        {
            healthRecoveredPercent = Mathf.Clamp01(healthRecoveredPercent);
            _currentHealth = Mathf.Min(_currentHealth + _currentHealth * healthRecoveredPercent, maxHealth);
        }
    }
}