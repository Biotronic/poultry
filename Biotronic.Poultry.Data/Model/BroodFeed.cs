using System;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodFeed : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public double? AmountKg { get; set; }

        public double? CostTotal { get; set; }

        public DateTime? Date { get; set; }

        public Silo Silo { get; set; }
    }
}