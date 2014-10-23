using System;
using PetaPoco;

namespace UnitOfWorkConsole
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}