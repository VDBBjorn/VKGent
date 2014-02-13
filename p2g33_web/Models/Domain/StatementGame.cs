using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace p2g33_web.Models.Domain
{
    public class StatementGame : Element
    {
        public StatementGame()
        {
            this.StatementGameQuestions = new List<StatementGameQuestion>();
        }
        public virtual IList<StatementGameQuestion> StatementGameQuestions { get; set; }
    }
}
