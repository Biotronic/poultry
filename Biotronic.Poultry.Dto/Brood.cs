using System;
using System.Collections.Generic;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class Brood : BaseDtoObject
    {
        public House House { get; set; }
        
        public User Owner { get; set; }

        public int BroodNumber { get; set; }

        public DateTime Received { get; set; }
        
        public DateTime? Ended { get; set; }
        
        public Veterinarian Veterinarian { get; set; }

        public Hatchery Hatchery { get; set; }

        public int MaleCount { get; set; }

        public int FemaleCount { get; set; }

        public Hybrid Hybrid { get; set; }

        public IEnumerable<DayRecord> Days { get; set; }

        public IEnumerable<BroodComment> Comments { get; set; }

        public IEnumerable<BroodDisinfection> Disinfections { get; set; }

        public IEnumerable<BroodFeed> Feeds { get; set; }

        public IEnumerable<BroodTreatment> Treatments { get; set; }

        public IEnumerable<BroodDelivery> Deliveries { get; set; }
    }
}