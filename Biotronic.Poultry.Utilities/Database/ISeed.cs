namespace Biotronic.Poultry.Utilities.Database
{
    public interface ISeed<in TRepository> where TRepository : IBaseDbRepository
    {
        void Run(TRepository repository);
    }
}