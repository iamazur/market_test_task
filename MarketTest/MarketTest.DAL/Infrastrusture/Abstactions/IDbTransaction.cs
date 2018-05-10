using System;
using System.Collections.Generic;
using System.Text;

namespace MarketTest.DAL.Infrastrusture
{
    public interface IDbTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
