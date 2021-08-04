using ProjectX.Scripts.Tools.Enums;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHealth;

        public void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
        }

        public void TakeDamage(float percent, PercentageType percentageType)
        {
        }

        public void Heal(float health)
        {
        }

        public void Heal(float percent, PercentageType percentageType)
        {
        }
    }
}