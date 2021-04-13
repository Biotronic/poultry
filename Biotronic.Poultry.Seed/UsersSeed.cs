using Biotronic.Poultry.Data;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Seed
{
    public class UsersSeed : ISeed<IPoultryRepository>
    {
        public void Run(IPoultryRepository repository)
        {
            repository.CreateUser("System", "", "");
        }
    }
}