using System;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodDisinfection : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }

        [MaxLength(255)]
        public string Treatment { get; set; }

        [MaxLength(255)]
        public string Amount { get; set; }

        public string Comment { get; set; }

        public DateTime? Date { get; set; }
    }
}