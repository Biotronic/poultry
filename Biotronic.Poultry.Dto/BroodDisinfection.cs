using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class BroodDisinfection : BaseDtoObject
    {
        public string Treatment { get; set; }

        public string Amount { get; set; }

        public string Comment { get; set; }
    }
}