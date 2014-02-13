using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public abstract class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public string Email { get; set; }
        public int ElementId { get; set; }
        public string LearningProcessCode { get; set; }
        public virtual LearningProcess LearningProcess { get; set; }
        public virtual Element Element { get; set; }
    }
}