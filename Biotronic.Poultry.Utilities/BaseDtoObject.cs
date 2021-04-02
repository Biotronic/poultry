using System.Collections;
using System.Collections.Generic;

namespace Biotronic.Poultry.Utilities
{
    public enum Action
    {
        None,
        Create,
        Update,
        Delete
    }

    public class BaseDtoObject
    {
        public Action Action { get; set; }
        
        public int Id { get; set; }
        
        public IList<string> Changes { get; set; }
    }
}