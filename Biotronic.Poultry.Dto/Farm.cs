using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class Farm : BaseDtoObject
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }
    }
}