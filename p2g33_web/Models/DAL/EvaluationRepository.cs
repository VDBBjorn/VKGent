using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly P2G33Context _context;
        private readonly DbSet<Evaluation> _evaluations;

        public EvaluationRepository(P2G33Context context)
        {
            this._context = context;
            _evaluations = _context.Evaluations;
        }

        public void Add(Evaluation evaluation)
        {
            _evaluations.Add(evaluation);
            _context.SaveChanges();
        }
    }
}