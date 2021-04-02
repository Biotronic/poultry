using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data.Model
{
    public class User : BaseDbObject
    {
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(32)]
        public string ZipCode { get; set; }

        public IEnumerable<Farm> Farms { get; set; }
    }
}
