using Biotronic.Poultry.Dto;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data
{
    public interface IPoultryRepository : IBaseDbRepository
    {
        void UpdateBrood(BroodUpdate brood);
        
        void CreateUser(string name, string email, string token);
    }
}