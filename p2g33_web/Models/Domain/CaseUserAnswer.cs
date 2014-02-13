using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public class CaseUserAnswer: UserAnswer
    {
        public int CaseQuestionId { get; set; }
        public int CaseAnswerId { get; set; }
        public virtual CaseQuestion CaseQuestion { get; set; }
        public virtual CaseAnswer CaseAnswer { get; set; }
    }
}