using System.Collections.Generic;
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

        public IEnumerable<House> Houses { get; set; }

        public IEnumerable<Silo> Silos { get; set; }

        public IEnumerable<FarmAccess> FarmAccess { get; set; }
    }
}