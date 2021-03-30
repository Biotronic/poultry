using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class BroodDelivery
    {
        [Key]
        public int Id { get; set; }

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