using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BasicAttack", menuName = "Scriptable Objects/Basic Attack")]
public class BasicAttack: BaseAbility
{
    [SerializeField] private string abilityName;
    [SerializeField] private Image icon;
    [SerializeField] private AnimationClip animation;
    [SerializeField] private Collider hitBoxPrefab;
    [SerializeField] private bool aimed;
    [SerializeField] private bool movementBlocking;
    [SerializeField] private float duration;
    [SerializeField] private float cooldown;

    public override string AbilityName
    {
        get => name;
        set => name = value;
    }
    public override Image Icon 
    {
        get => icon; 
        set => icon = value; 
    }
    public override bool MovementBlocking
    {
        get => movementBlocking;
        set => movementBlocking = value;
    }
    public override bool Aimed
    {
        get => aimed; 
        set => aimed = value;
    }
    public override float Duration
    {
        get => duration; 
        set => duration = value;
    }
    public override float Cooldown
    {
        get => cooldown; 
        set => cooldown = value;
    }

    public override AnimationClip Animation
    {
        get => animation; 
        set => animation = value;
    }
    
    public override Collider HitBoxPrefab
    {
        get => hitBoxPrefab;
        set => hitBoxPrefab = value;
    }

    public override float CooldownTimer { get; set; }

    public override IEnumerator PerformAbility(Collider hitBoxInstance)
    {
        hitBoxInstance.enabled = true;
        yield return null;

        hitBoxInstance.enabled = false;
    }

}