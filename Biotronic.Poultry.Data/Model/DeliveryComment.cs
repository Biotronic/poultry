using System.ComponentModel.DataAnnotations;

namespace Biotronic.Poultry.Data.Model
{
    public class DeliveryComment
    {
        [Key]
        public int Id { get; set; }

        public BroodDelivery Delivery { get; set; }

        public string Comment { get; set; }

        public User User { get; set; }
    }
}