using System.Collections.Generic;
using System.Linq;

namespace p2g33_web.Models.Domain
{
    public partial class CaseQuestion
    {
        public int caseQuestionId { get; set; }
        public string consideration { get; set; }
        public string question { get; set; }
        public virtual IList<CaseAnswer> CaseAnswers { get; set; }

        public CaseQuestion()
        {
            this.CaseAnswers = new List<CaseAnswer>();
        }

        public CaseAnswer getAnswerById(int id)
        {
            return CaseAnswers.FirstOrDefault(answer => answer.caseAnswerId == id);
        }
    }
}
