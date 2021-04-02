using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class Hatchery : BaseDtoObject
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}