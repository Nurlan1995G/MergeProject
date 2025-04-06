namespace Assets._Project.Scripts.Service
{
    public interface IServiceLocator
    {
        void RegisterSingle<TService>(TService implementation) where TService : IService;
        TService Resolve<TService>() where TService : IService;
        bool IsRegistered<TService>() where TService : IService;
        void Unregister<TService>() where TService : IService;
        void ClearAll();
    }
}
