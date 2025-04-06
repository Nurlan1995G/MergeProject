using System.Collections.Generic;
using System;

namespace Assets._Project.Scripts.Service
{
    public class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private readonly Dictionary<Type, IService> _services = new();

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            _services[typeof(TService)] = implementation;

        public TService Resolve<TService>() where TService : IService
        {
            if (_services.TryGetValue(typeof(TService), out var service))
                return (TService)service;

            throw new Exception($"Service {typeof(TService).Name} is not registered.");
        }

        public bool IsRegistered<TService>() where TService : IService =>
            _services.ContainsKey(typeof(TService));

        public void Unregister<TService>() where TService : IService =>
            _services.Remove(typeof(TService));

        public void ClearAll() => _services.Clear();
    }
}
