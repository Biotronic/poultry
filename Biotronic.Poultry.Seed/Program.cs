using Biotronic.Poultry.Data;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Seed
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var context = new PoultryDbContext();
            var userHandler = new UserHandler();

            var runner = new SeedRunner<IPoultryRepository>(new PoultryRepository(context, userHandler));
            runner.Add(new UsersSeed());
            runner.Seed();
        }
    }
}
