namespace ProjectX.Scripts.Framework.Abilities
{
    public interface IAbility
    {
        void Use();
        void Cancel();
        void Initialize(AbilitySlot abilitySlot);
        void Deinitialize();
    }
}