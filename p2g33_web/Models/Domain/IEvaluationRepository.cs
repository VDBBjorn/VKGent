using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.Domain
{
    public interface IEvaluationRepository
    {
        void Add(Evaluation evaluation);
    }
}