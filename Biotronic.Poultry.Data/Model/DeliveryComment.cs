using Biotronic.Poultry.Utilities.Database;

namespace Biotronic.Poultry.Data.Model
{
    public class DeliveryComment : BaseDbObject
    {
        public BroodDelivery Delivery { get; set; }

        public string Comment { get; set; }

        public User User { get; set; }
    }
}