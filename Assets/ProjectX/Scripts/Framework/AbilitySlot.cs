using ProjectX.Scripts.Framework.Abilities;
using UnityEngine;

namespace ProjectX.Scripts.Framework
{
    // TODO DO I NEED TO HAVE THIS AS A SEPARATE CLASS? IT'S NOT UI BUT IT FEELS WEIRD HAVING TWO CLASSES FOR ALMOST THE SAME THING
    public class AbilitySlot
    {
        private readonly GameObject _user;
        private IAbility _ability;

        public AbilitySlot(GameObject user, IAbility ability)
        {
            _ability = ability;
            _user = user;
            
            _ability.Initialize(_user);
        }
        
        public void UseAbility()
        {
            _ability.Use();
        }

        public void CancelAbility()
        {
            _ability.Cancel();
        }

        public void ChangeAbility(IAbility newAbility)
        {
            _ability.Deinitialize();
            _ability = newAbility;
            _ability.Initialize(_user);
        }

        public Ability GetAbility()
        {
            return (Ability)_ability;
        }
    }
}