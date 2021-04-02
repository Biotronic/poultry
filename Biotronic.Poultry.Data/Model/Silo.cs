using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class Silo : BaseDbObject
    {
        [Index]
        public House House { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Comment { get; set; }
    }
}