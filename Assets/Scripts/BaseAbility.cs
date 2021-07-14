public abstract class BaseAbility
{
    public abstract string Name { get; set; }
    public abstract string IconPath { get; set; }
    public abstract bool MovementBlocking { get; set; }
    public abstract bool Aimed { get; set; }
    public abstract float Duration { get; set; }
    public abstract float Cooldown { get; set; }

    public abstract void Start();
    public abstract void Finish();
}