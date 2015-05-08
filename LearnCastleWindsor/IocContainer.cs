using System.Collections.Generic;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace LearnCastleWindsor
{
    public class IocContainer : IIocContainer
    {
        public static IIocContainer Instance { get; private set; }
        public IWindsorContainer Container { get; private set; }
        
        public static IIocContainer Initialize()
        {
            if (Instance != null)
            {
                return Instance;
            }

            var container = new WindsorContainer()
                .Install(FromAssembly.This());

            Instance = new IocContainer() {Container = container};

            return Instance;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public T Resolve<T>(string key)
        {
            return Container.Resolve<T>(key);
        }

        public T[] ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }
    }
}