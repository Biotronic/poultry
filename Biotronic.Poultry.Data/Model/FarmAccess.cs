using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class FarmAccess : BaseDbObject
    {
        [Index]
        public Farm Farm { get; set; }

        [Index]
        public User User { get; set; }
        
        public AccessLevel Access { get; set; }
    }
}