using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Utilities.Database
{
    public abstract class BaseDbObject
    {
        [Key]
        public int Id { get; set; }
    }
}