using Biotronic.Poultry.Data;
using Biotronic.Poultry.Utilities;
using Biotronic.Poultry.Utilities.Database;
using Microsoft.EntityFrameworkCore;

namespace Biotronic.Poultry.Tests
{
    public abstract class TestBase
    {
        protected PoultryDbContext Context { get; }
        protected IPoultryRepository Repository { get; }
        protected Configuration Config { get; }

        protected TestBase()
        {
            Config = new ConfigurationBuilder<Configuration>()
                .UseAppSettings()
                .Build();
            
            var options = new DbContextOptionsBuilder<PoultryDbContext>()
                .UseSqlServer(Config.ConnectionString)
                .Options;


            Context = new PoultryDbContext(options);
            Repository = new PoultryRepository(Context, new UserHandler());
        }

    }
}