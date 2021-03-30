using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodTreatment
    {
        [Key]
        public int Id { get; set; }

        public string Treatment { get; set; }

        public string Illness { get; set; }

        public string Comment { get; set; }
    }
}