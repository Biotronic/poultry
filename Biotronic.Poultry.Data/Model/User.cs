using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public IEnumerable<Farm> Farms { get; set; }
    }
}
