using System.Collections.Generic;
using Biotronic.Poultry.Data.Model;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data
{
    public class PoultryRepository : BaseDbRepository<PoultryDbContext, PoultryProfile>, IPoultryRepository
    {
        public PoultryRepository(PoultryDbContext context, UserHandler userHandler) : base(context, userHandler)
        {
        }

        public void UpdateBrood(Dto.BroodUpdate brood)
        {
            using var batch = Context.StartBatch();

            UpdateEntities<IEnumerable<Brood>>(brood.Broods);
        }

        public void CreateUser(string name, string email, string token)
        {
        }
    }
}
