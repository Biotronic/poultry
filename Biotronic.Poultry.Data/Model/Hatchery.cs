using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class Hatchery : BaseDbObject
    {
        [Index]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }
    }
}