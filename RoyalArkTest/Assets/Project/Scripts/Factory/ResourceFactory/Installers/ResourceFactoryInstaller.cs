using Zenject;

namespace RoyalArkTest
{
    public class ResourceFactoryInstaller : MonoInstaller
    {
        
        public override void InstallBindings() => BindResourceFactory();

        private void BindResourceFactory() => Container.Bind<IResourceFactory>().To<ResourceFactory>().AsSingle();
    }
}