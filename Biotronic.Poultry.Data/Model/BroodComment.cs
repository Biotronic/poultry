using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodComment
    {
        [Key]
        public int Id { get; set; }

        //public Brood Brood { get; set; }
        
        public string Comment { get; set; }

        public User User { get; set; }
    }
}