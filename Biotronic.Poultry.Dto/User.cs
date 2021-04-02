using System.Collections.Generic;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class User : BaseDtoObject
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public IEnumerable<Farm> Farms { get; set; }
    }
}