using NHibernate;

namespace MyApplication.UnitOfWork.Implementation
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private IUnitOfWorkFactory SessionFactory { get; set; }
        private ISession Session { get; set; }

        public NHibernateUnitOfWork(IUnitOfWorkFactory sessionFactory, ISession session)
        {
            SessionFactory = sessionFactory;
            Session = session;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}