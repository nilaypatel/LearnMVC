using System;
using System.IO;
using System.Xml;
using NHibernate;
using NHibernate.Cfg;

namespace MyApplication.UnitOfWork.Implementation
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private const string nhibernateConfig = "nhibernate.cfg.xml";

        private ISession currentSession;

        public ISession CurrentSession
        {
            get { return currentSession; }
        }

        private Configuration configuration;
        public Configuration Configuration 
        {
            get
            {
                if (configuration != null)
                {
                    return configuration;
                }

                configuration = new Configuration();

                var hibernateConfig = nhibernateConfig;

                //if not rooted, assume path from base directory
                if (Path.IsPathRooted(hibernateConfig) == false)
                {
                    hibernateConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hibernateConfig);
                }

                if (File.Exists(hibernateConfig))
                {
                    configuration.Configure(new XmlTextReader(hibernateConfig));
                }

                return configuration;
            }
        }


        private ISessionFactory sessionFactory;
        public ISessionFactory SessionFactory {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Configuration.BuildSessionFactory();
                }

                return sessionFactory;
            }
        }

        public IUnitOfWork Create()
        {
            var session = CreateSession();
            session.FlushMode = FlushMode.Commit;
            currentSession = session;

            return new NHibernateUnitOfWork(this, session);
        }

        private ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }


        public void DisposeUnitOfWork()
        {
            throw new System.NotImplementedException();
        }
    }
}