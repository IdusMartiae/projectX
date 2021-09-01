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

        private void Update()
        {
            healthBarFill.fillAmount = healthComponent.GetCurrentHealthPercent();
            healthPointText.text = $"{healthComponent.CurrentHealth:F0}/{healthComponent.MaxHealth:F0}";
        }
    }
}