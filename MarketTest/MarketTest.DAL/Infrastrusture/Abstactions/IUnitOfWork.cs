using System;
using System.Collections.Generic;
using System.Text;

namespace MarketTest.DAL.Infrastrusture
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>()
            where T : class;

        void SaveChanges();

        IDbTransaction BeginTransaction();
    }
}
