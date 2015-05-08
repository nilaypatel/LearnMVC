using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;

namespace MyApplication.UnitOfWork.Tests
{
    [TestFixture]
    public class UnitOfWorkFixture
    {
        [Test]
        public void can_start_unit_of_work()
        {
            //ARANGE
            var unitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            var unitOfWorkFactoryMock = MockRepository.GenerateMock<IUnitOfWorkFactory>();
            unitOfWorkFactoryMock.Expect(f => f.Create())
                .Return(unitOfWork);

            //ACT
            UnitOfWork.UnitOfWorkFactory = unitOfWorkFactoryMock;
            UnitOfWork.Start();

            //ASSERT
            unitOfWorkFactoryMock.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void can_not_start_unit_of_work_if_already_started()
        {
            //ARANGE
            var unitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            var unitOfWorkFactoryMock = MockRepository.GenerateMock<IUnitOfWorkFactory>();
            unitOfWorkFactoryMock.Expect(f => f.Create())
                .Return(unitOfWork);

            //ACT
            UnitOfWork.UnitOfWorkFactory = unitOfWorkFactoryMock;
            UnitOfWork.Start();
            UnitOfWork.Start();

            //ASSERT
            unitOfWorkFactoryMock.VerifyAllExpectations();
        }

        [Test]
        public void can_access_current_unit_of_work()
        {
            //ARANGE
            var unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
            var unitOfWorkFactoryStub = MockRepository.GenerateStub<IUnitOfWorkFactory>();
            unitOfWorkFactoryStub
                .Stub(f => f.Create())
                .Return(unitOfWork);

            //ACT
            UnitOfWork.UnitOfWorkFactory = unitOfWorkFactoryStub;
            var uow = UnitOfWork.Start();

            //ASSERT
            Assert.AreSame(uow, UnitOfWork.Current);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void can_not_access_current_unit_of_work_if_not_started()
        {
            var current = UnitOfWork.Current;
        }

        [TearDown]
        public void TearDown()
        {
            var fieldInfo = typeof (UnitOfWork).GetField("unitOfWork",
                BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic);

            fieldInfo.SetValue(null, null);
        }

        [Test]
        public void can_get_valid_current_session_if_unt_of_work_is_started()
        {
            //ARANGE
            var unitOfWorkFactoryMock = MockRepository.GenerateMock<IUnitOfWorkFactory>();

            var unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
            unitOfWorkFactoryMock
                .Expect(f => f.Create())
                .Return(unitOfWork);

            var sessionStub = MockRepository.GenerateStub<ISession>();
            unitOfWorkFactoryMock
                .Expect(f => f.CurrentSession)
                .Return(sessionStub);

            //ACT
            //ASSERT
            UnitOfWork.UnitOfWorkFactory = unitOfWorkFactoryMock;
            using (UnitOfWork.Start())
            {
                var session = UnitOfWork.CurrentSession;
                Assert.IsNotNull(session);
            }

            unitOfWorkFactoryMock.VerifyAllExpectations();
        }
    }
}
