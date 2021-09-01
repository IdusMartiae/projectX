using ProjectX.Scripts.Framework;
using UnityEngine;
using Zenject;

namespace ProjectX.Scripts.Environment.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Material resourceMaterial;
        [SerializeField] private string propertyName;
        
        private CharacterHealth _playerHealth;

        [Inject]
        private void Construct(Player.Player player)
        {
            _playerHealth = player.GetComponent<CharacterHealth>();
        }
        
        private void Update()
        {
            resourceMaterial.SetFloat(propertyName, _playerHealth.GetCurrentHealthPercent());
        }
    }
}