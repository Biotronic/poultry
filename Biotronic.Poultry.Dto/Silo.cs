using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class Silo : BaseDtoObject
    {
        public House House { get; set; }

        public string Name { get; set; }
    }
}