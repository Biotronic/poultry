using System.Threading.Tasks;
using Biotronic.Poultry.Dto;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data
{
    public class PoultryRepository : BaseDbRepository<PoultryDbContext>, IPoultryRepository
    {
        public PoultryRepository(PoultryDbContext context, UserHandler userHandler) : base(context, userHandler)
        {
        }

        public async Task UpdateBrood(BroodUpdate brood)
        {
            await using var batch = Context.StartBatch();


            throw new System.NotImplementedException();
        }
    }
}
