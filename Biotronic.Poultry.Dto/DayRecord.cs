using System.Collections.Generic;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class DayRecord : BaseDtoObject
    {
        public Brood Brood { get; set; }

        public int Age { get; set; }

        public int DeadMales { get; set; }

        public int DeadFemales { get; set; }

        public int WeightMales { get; set; }

        public int WeightFemales { get; set; }

        public int FeedUsage { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public IEnumerable<DayComment> Comments { get; set; }
    }
}