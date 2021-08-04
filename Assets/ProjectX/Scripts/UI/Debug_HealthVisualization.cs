using ProjectX.Scripts.Framework;
using UnityEngine;

namespace ProjectX.Scripts.UI
{
    public class Debug_HealthVisualization : MonoBehaviour
    {
        [SerializeField] private CharacterHealth healthComponent;
        [SerializeField] private TextMesh textHealth;
            
        void Update()
        {
            textHealth.text = $"{Mathf.Ceil(healthComponent.CurrentHealth)} / {healthComponent.MaxHealth}";
        }
    }
}
