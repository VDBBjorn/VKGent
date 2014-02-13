using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public class StatementGameUserAnswer: UserAnswer
    {
        public int StatementGameAnswerId { get; set; }
        public int StatementGameQuestionId { get; set; }
        public virtual StatementGameAnswer StatementGameAnswer { get; set; }
        public virtual StatementGameQuestion StatementGameQuestion { get; set; }
    }
}