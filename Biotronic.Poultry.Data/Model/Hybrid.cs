using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data.Model
{
    public class Hybrid : BaseDbObject
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public string Comment { get; set; }
    }
}