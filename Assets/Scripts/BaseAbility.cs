using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseAbility : ScriptableObject
{
    
    public abstract string AbilityName { get; set; }
    public abstract Image Icon { get; set; }
    public abstract bool MovementBlocking { get; set; }
    public abstract bool Aimed { get; set; }
    public abstract float Duration { get; set; }
    public abstract float Cooldown { get; set; }
    public abstract AnimationClip Animation { get; set; }
    public abstract Collider HitBoxPrefab { get; set; }
    public abstract float CooldownTimer { get; set; }

    public abstract IEnumerator PerformAbility(Collider hitBoxInstance);
    public IEnumerator PerformCooldown()
    {
        CooldownTimer = Cooldown;
        while (CooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
            yield return null;
        }

        CooldownTimer = 0f;
    }
}