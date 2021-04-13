using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class User : BaseDbObject
    {
        [MaxLength(255)]
        [Index(Unique = true)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(32)]
        public string ZipCode { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }

    public class Role : BaseDbObject
    {

    }
}
