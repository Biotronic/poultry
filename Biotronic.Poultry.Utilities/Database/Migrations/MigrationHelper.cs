using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biotronic.Poultry.Utilities.Database.Migrations
{
    public class MigrationHelper<TContext> where TContext : DbContext, IBaseDbContext
    {
        private TContext Context { get; }

        public MigrationHelper(TContext context)
        {
            Context = context;
        }

        public IEnumerable<string> Migrations => Context.Database.GetMigrations();

        public string CurrentMigration => Context.Database.GetAppliedMigrations().LastOrDefault();

        public void Clear()
        {
            Context.Database.EnsureDeleted();
        }

        public void Migrate()
        {
            Debug.Assert(Migrations.Any(), "No migrations defined.");
            Context.Database.EnsureCreated();
        }
    }
}
