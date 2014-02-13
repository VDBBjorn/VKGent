using System;

namespace p2g33_web.Models.Domain
{
    public partial class CaseAnswer
    {
        public int caseAnswerId { get; set; }
        public string answer { get; set; }
        public string feedback { get; set; }
        public int? nextQuestionId { get; set; }
        public virtual CaseQuestion nextQuestion { get; set; }
    }
}
