using System.Threading.Tasks;
using Biotronic.Poultry.Dto;

namespace Biotronic.Poultry.Data
{
    public interface IPoultryRepository
    {
        Task UpdateBrood(BroodUpdate brood);
    }
}