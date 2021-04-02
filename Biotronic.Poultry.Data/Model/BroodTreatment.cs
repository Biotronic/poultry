using System;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodTreatment : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }

        [MaxLength(255)]
        public string Treatment { get; set; }

        [MaxLength(255)]
        public string Illness { get; set; }

        public string Comment { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}