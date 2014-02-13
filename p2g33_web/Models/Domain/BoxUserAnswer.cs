using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public class BoxUserAnswer: UserAnswer
    {
        public int BoxQuestionId { get; set; }
        public string BoxAnswer { get; set; }
        public string BoxMotivation { get; set; }
        public virtual BoxQuestion BoxQuestion { get; set; }
    }
}