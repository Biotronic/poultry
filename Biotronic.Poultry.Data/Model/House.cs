using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        public Farm Farm { get; set; }

        public User Owner { get; set; }
    }
}