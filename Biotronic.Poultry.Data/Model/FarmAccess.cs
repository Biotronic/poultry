using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class FarmAccess
    {
        [Key]
        public int Id { get; set; }

        public Farm Farm { get; set; }

        public User User { get; set; }
        
        public AccessLevel Access { get; set; }
    }
}