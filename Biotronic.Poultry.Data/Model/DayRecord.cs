using System.Collections.Generic;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class DayRecord : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }

        public int Age { get; set; }

        public int? DeadMales { get; set; }

        public int? DeadFemales { get; set; }

        public double? WeightMalesKg { get; set; }
        public double? WeightFemalesKg { get; set; }
        public double? FeedUsageKg { get; set; }
        public double? WaterUsageLiters { get; set; }
        public double? Temperature { get; set; }
        public double? HumidityPct { get; set; }

        public IEnumerable<DayComment> Comments { get; set; }
    }
}