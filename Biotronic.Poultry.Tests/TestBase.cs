using System.Threading.Tasks;
using Biotronic.Poultry.Data;
using Biotronic.Poultry.Utilities;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biotronic.Poultry.Tests
{
    public abstract class TestBase
    {
        protected PoultryDbContext Context { get; }
        protected IPoultryRepository Repository { get; }
        protected Configuration Config { get; }

        private MigrationHelper<PoultryDbContext> MigrationHelper { get; }

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

            MigrationHelper = new MigrationHelper<PoultryDbContext>(Context);
        }

        [TestInitialize]
        public void TestBaseInit()
        {
            MigrationHelper.Clear();
            MigrationHelper.Migrate();
        }

        [TestCleanup]
        public void TestBaseCleanup()
        {
            MigrationHelper.Clear();
        }
    }
}