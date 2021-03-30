using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodDisinfection
    {
        [Key]
        public int Id { get; set; }

        public string Treatment { get; set; }

        public string Amount { get; set; }

        public string Comment { get; set; }
    }
}