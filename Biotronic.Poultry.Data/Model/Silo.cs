using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class Silo
    {
        [Key]
        public int Id { get; set; }

        public House House { get; set; }

        public string Name { get; set; }
    }
}