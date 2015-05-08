using Castle.Windsor;

namespace LearnCastleWindsor
{
    public interface IIocContainer
    {
        IWindsorContainer Container { get; }

        T Resolve<T>();

        T Resolve<T>(string key);

        T[] ResolveAll<T>();
    }
}