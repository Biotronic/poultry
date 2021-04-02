using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class BroodComment : BaseDtoObject
    {
        public Brood Brood { get; set; }
        
        public string Comment { get; set; }

        public User User { get; set; }
    }
}