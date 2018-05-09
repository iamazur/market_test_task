using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketTest.DAL.Infrastrusture
{
    internal sealed class EfDbTransaction : IDbTransaction
    {
        private IDbContextTransaction _transaction;

        internal EfDbTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit() => _transaction.Commit();

        public void Rollback() => _transaction.Rollback();

        public void Dispose() => _transaction.Dispose();
    }
}
