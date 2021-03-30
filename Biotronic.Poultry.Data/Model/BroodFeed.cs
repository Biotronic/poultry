using System;
using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodFeed
    {
        [Key]
        public int Id { get; set; }

        public Brood Brood { get; set; }

        public string Type { get; set; }

        public float AmountKg { get; set; }

        public double CostTotal { get; set; }

        public DateTime Date { get; set; }

        public Silo Silo { get; set; }
    }
}