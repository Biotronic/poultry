using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class Veterinarian
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}