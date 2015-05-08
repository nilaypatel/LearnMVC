using MyApplication.UnitOfWork.Implementation;
using NHibernate;
using NUnit.Framework;

namespace MyApplication.UnitOfWork.Tests
{
    [TestFixture]
    public class UnitOfWorkFactoryFixture
    {
        private IUnitOfWorkFactory unitOfWorkFactory;

        [SetUp]
        public void Setup()
        {
            unitOfWorkFactory = new UnitOfWorkFactory();
        }

        [Test]
        public void can_create_unit_of_work()
        {
            //ARANGE
            //ACT
            var unitOfWork = unitOfWorkFactory.Create();

            //ASSERT
            Assert.IsNotNull(unitOfWork);
            Assert.IsNotNull(unitOfWorkFactory.CurrentSession);

            Assert.AreEqual(unitOfWorkFactory.CurrentSession.FlushMode, FlushMode.Commit);
        }

        [Test]
        public void can_configure_nhibernate()
        {
            //ARANGE
            //ACT
            var configuration = unitOfWorkFactory.Configuration;

            //ASSERT
            Assert.IsNotNull(configuration);

            Assert.AreEqual("NHibernate.Connection.DriverConnectionProvider",
                            configuration.Properties["connection.provider"]);
            Assert.AreEqual("NHibernate.Dialect.MsSql2008Dialect",
                            configuration.Properties["dialect"]);
            Assert.AreEqual("NHibernate.Driver.SqlClientDriver",
                            configuration.Properties["connection.driver_class"]);
            Assert.AreEqual("development-localhost",
                            configuration.Properties["connection.connection_string_name"]);
        }

        [Test]
        public void can_create_and_access_session_factory()
        {
            //ARANGE
            //ACT
            var sessionFactory = unitOfWorkFactory.SessionFactory;

            //ASSERT
            Assert.IsNotNull(sessionFactory);
        }

    }
}