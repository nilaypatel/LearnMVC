using System;
using NHibernate;

namespace MyApplication.UnitOfWork
{
    public static class UnitOfWork
    {
        public static IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public static ISession CurrentSession {
            get { return UnitOfWorkFactory.CurrentSession; }
        }

        public static IUnitOfWork Current
        {
            get
            {
                if (unitOfWork == null)
                {
                    throw new InvalidOperationException("Unit of work is not started yet. Cannot access current");
                }

                return unitOfWork;
            }
        }

        private static IUnitOfWork unitOfWork;
        public static IUnitOfWork Start()
        {
            if (unitOfWork != null)
            {
                throw new InvalidOperationException("cannot start more than one unit of work at the same time");
            }

            unitOfWork = UnitOfWorkFactory.Create();
            return unitOfWork;
        }
    }
}