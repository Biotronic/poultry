using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class BroodTreatment : BaseDtoObject
    {
        public string Treatment { get; set; }

        public string Illness { get; set; }

        public string Comment { get; set; }
    }
}