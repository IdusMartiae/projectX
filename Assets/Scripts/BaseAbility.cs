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
    public abstract GameObject HitZone { get; set; }

    public abstract void Start();
    public abstract void Finish();
}