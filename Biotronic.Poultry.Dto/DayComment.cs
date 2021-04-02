using Biotronic.Poultry.Utilities;

namespace Biotronic.Poultry.Dto
{
    public class DayComment : BaseDtoObject
    {
        public DayRecord Day { get; set; }

        public string Comment { get; set; }
        
        public User User { get; set; }
    }
}