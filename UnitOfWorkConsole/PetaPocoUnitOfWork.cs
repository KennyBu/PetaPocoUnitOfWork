using PetaPoco;

namespace UnitOfWorkConsole
{
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private Transaction _petaTransaction;
        private readonly Database _db;

        public PetaPocoUnitOfWork(Database database)
        {
            _db = database;
        }

        public void Dispose()
        {
            _petaTransaction.Dispose();
        }

        public void BeginTransaction()
        {
            _petaTransaction = new Transaction(_db);
        }

        public void Rollback()
        {
            _petaTransaction.Dispose();
        }

        public Database Db
        {
            get { return _db; }
        }

        public void Commit()
        {
            _petaTransaction.Complete();
        }

       
    }
}