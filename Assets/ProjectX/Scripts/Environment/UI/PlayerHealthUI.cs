using ProjectX.Scripts.Framework;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private string propertyName;

        private CharacterHealth _playerHealth;
        private MaterialPropertyBlock _materialProperties;
        private MeshRenderer _meshRenderer;

        [Inject]
        private void Construct(Player.Player player)
        {
            _playerHealth = player.GetComponent<CharacterHealth>();
        }

        private void Awake()
        {
            _materialProperties = new MaterialPropertyBlock();
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            _playerHealth.HealthChanged += UpdateUI;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= UpdateUI;
        }

        private void UpdateUI(float healthPoints, float healthPercent, float maxHealth)
        {
            _materialProperties.SetFloat(propertyName, healthPercent);
            _meshRenderer.SetPropertyBlock(_materialProperties);
        }
    }
}