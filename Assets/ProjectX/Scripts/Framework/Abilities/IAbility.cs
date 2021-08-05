using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public interface IAbility
    {
        void Use();
        void Cancel();
        void Initialize(GameObject user);
        void Deinitialize();
    }
}