using System.Collections.Generic;

namespace Biotronic.Poultry.Dto
{
    public class BroodUpdate
    {
        public IEnumerable<Brood> Broods { get; set; }
        public User User { get; set; }
    }
}
