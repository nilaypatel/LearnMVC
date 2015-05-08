using NHibernate;
using NHibernate.Cfg;

namespace MyApplication.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        Configuration Configuration { get; }
        
        ISession CurrentSession { get; }

        ISessionFactory SessionFactory { get; }

        IUnitOfWork Create();

        void DisposeUnitOfWork();
    }
}