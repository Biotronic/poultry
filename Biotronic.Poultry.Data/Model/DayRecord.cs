using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class DayRecord
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public Brood Brood { get; set; }

        public int Age { get; set; }

        public int DeadMales { get; set; }

        public int DeadFemales { get; set; }

        public int WeightMales { get; set; }

        public int WeightFemales { get; set; }

        public int FeedUsage { get; set; }

        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public IEnumerable<DayComment> Comments { get; set; }
    }
}