using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodComment : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }
        
        public string Comment { get; set; }

        public User User { get; set; }
    }
}