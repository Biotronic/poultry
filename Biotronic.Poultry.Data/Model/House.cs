using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class House : BaseDbObject
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [Index]
        public Farm Farm { get; set; }

        [Index]
        public User Owner { get; set; }
    }
}