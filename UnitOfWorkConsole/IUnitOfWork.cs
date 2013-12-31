using System;
using PetaPoco;

namespace UnitOfWorkConsole
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Database Db { get; }
    }
}