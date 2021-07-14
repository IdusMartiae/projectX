using Zenject;

namespace Installers
{
    public class CharacterAbilitiesComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterAbilitiesComponent>().AsSingle();
        }
    }
}