using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class Hybrid
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}