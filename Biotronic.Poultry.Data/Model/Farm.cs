using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data.Model
{
    public class Farm : BaseDbObject
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(16)]
        public string ZipCode { get; set; }
    }
}