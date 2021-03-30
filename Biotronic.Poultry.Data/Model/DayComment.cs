using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class DayComment
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public DayRecord Day { get; set; }

        public string Comment { get; set; }

        [Index]
        public User User { get; set; }
    }
}