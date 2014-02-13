using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace p2g33_web.Models.Domain
{
    public class Box : Element
    {
        public string theme { get; set; }
        public virtual IList<BoxQuestion> questions { get; set; }
//        public Dictionary<string, bool> images { get; set; }

        public Box()
        {
            questions = new List<BoxQuestion>();
        }
    }
}
