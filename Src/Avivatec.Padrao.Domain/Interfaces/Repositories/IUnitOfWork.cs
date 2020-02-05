using System;
using System.Data;

namespace Avivatec.Padrao.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollBack();

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }
    }
}
