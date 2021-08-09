using UnityEngine;

namespace ProjectX.Scripts.Framework.Abilities
{
    public interface IAbility
    {
        public void Use();
        public void Cancel();
        public void Initialize(GameObject user);
        public void Deinitialize();
    }
}