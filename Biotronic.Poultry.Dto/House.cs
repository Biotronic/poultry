using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class House : BaseDtoObject
    {
        public Farm Farm { get; set; }

        public User Owner { get; set; }
    }
}