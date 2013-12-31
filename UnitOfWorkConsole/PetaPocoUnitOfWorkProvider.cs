namespace UnitOfWorkConsole
{
    public class PetaPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new PetaPocoUnitOfWork();
        }
    }

    
}