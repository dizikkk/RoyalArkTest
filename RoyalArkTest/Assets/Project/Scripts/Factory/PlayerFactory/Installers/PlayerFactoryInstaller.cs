using Zenject;

namespace RoyalArkTest
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindRecyclerFactory();

        private void BindRecyclerFactory() => Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
    }
}