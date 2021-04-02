using Biotronic.Poultry.Dto;

namespace Biotronic.Poultry.Data
{
    public interface IPoultryRepository
    {
        void UpdateBrood(BroodUpdate brood);
    }
}