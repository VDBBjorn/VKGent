using System;
using System.Collections.Generic;

namespace p2g33_web.Models.Domain
{
    public partial class StatementGameQuestion
    {
        public StatementGameQuestion()
        {
            this.StatementGameQuestionAnswers = new List<StatementGameAnswer>();
        }

        public int statementGameQuestionId { get; set; }
        public string question { get; set; }
        public virtual IList<StatementGameAnswer> StatementGameQuestionAnswers { get; set; }
    }
}
