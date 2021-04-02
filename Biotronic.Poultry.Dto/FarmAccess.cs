using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class FarmAccess : BaseDtoObject
    {
        public Farm Farm { get; set; }

        public User User { get; set; }
        
        public AccessLevel Access { get; set; }
    }
}