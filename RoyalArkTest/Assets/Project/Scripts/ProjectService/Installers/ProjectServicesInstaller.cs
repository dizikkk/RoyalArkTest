using Zenject;

namespace RoyalArkTest
{
    public class ProjectServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindUIService();
            BindPlayerService();
        }

        private void BindPlayerService() => Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();

        private void BindUIService() => Container.Bind<IUIService>().To<UIService>().AsSingle();
    }
}