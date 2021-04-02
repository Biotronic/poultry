using System;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class BroodFeed : BaseDtoObject
    {
        public Brood Brood { get; set; }

        public string Type { get; set; }

        public double AmountKg { get; set; }

        public double CostTotal { get; set; }

        public DateTime Date { get; set; }

        public Silo Silo { get; set; }
    }
}