using PetaPoco;

namespace UnitOfWorkConsole
{
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _db;

        public PetaPocoUnitOfWork()
        {
            _db = new Database("sqlserverce");
            _petaTransaction = new Transaction(_db);
        }

        public PetaPocoUnitOfWork(string dbName)
        {
            _db = new Database(dbName);
            _petaTransaction = new Transaction(_db);
        }

        public PetaPocoUnitOfWork(Database database)
        {
            _db = database;
            _petaTransaction = new Transaction(_db);
        }

        public void Dispose()
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