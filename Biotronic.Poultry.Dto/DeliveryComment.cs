using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class DeliveryComment : BaseDtoObject
    {
        public BroodDelivery Delivery { get; set; }

        public string Comment { get; set; }

        public User User { get; set; }
    }
}