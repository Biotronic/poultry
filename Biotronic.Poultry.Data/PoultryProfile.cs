using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data
{
    public class PoultryProfile : BaseDbProfile<PoultryDbContext>
    {
        public PoultryProfile(PoultryDbContext context) : base(context, typeof(Dto.Brood).Assembly)
        {
        }
    }
}