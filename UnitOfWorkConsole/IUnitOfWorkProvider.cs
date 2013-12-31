namespace UnitOfWorkConsole
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork(); 
    }
}