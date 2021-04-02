using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class DayComment : BaseDbObject
    {
        [Index]
        public DayRecord Day { get; set; }

        public string Comment { get; set; }

        [Index]
        public User User { get; set; }
    }
}