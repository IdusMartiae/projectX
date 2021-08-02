using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        
        private float _currentHealth;

        // TODO REMOVE AFTER DEBUGGING
        public float CurrentHealth => _currentHealth;
        public float MaxHealth => maxHealth;
        
        public void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
            Debug.Log($"{gameObject.name}'s health is {_currentHealth} points");
            if (_currentHealth == 0)
            {
                Debug.Log($"{gameObject.name} died.");
            } 
        }
        
        
    }
}