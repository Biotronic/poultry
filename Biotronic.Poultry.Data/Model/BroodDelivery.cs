using System;
using System.Collections.Generic;
using Biotronic.Poultry.Utilities.Database;
using Biotronic.Poultry.Utilities.Database.Attributes;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodDelivery : BaseDbObject
    {
        [Index]
        public Brood Brood { get; set; }

        public DateTime? FecesSampleSent { get; set; }

        public DateTime? SelfReportSent { get; set; }

        public DateTime? FinalFeedStarted { get; set; }

        public DateTime? FeedEmpty { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int? AnimalsDelivered { get; set; }

        public double? WeightDeliveredKg { get; set; }

        public IEnumerable<DeliveryComment> Comments { get; set; }
    }
}