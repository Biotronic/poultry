using System;
using System.Collections.Generic;
using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class BroodDelivery : BaseDtoObject
    {
        public Brood Brood { get; set; }

        public DateTime FecesSampleSent { get; set; }

        public DateTime FooSent { get; set; }

        public DateTime FinalFeedStarted { get; set; }

        public DateTime FeedEmpty { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int AnimalsDelivered { get; set; }

        public double? WeightDeliveredKg { get; set; }

        public IEnumerable<DeliveryComment> Comments { get; set; }
    }
}