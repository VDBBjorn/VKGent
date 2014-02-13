using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public partial class StatementGameAnswer
    {
        [Key]
        public int statementGameAnswerId { get; set; }
        public int statementGameQuestionId { get; set; }
        public string answer { get; set; }
    }
}