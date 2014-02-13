using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class CaseMap : EntityTypeConfiguration<Case>
    {
        public CaseMap()
        {
            this.HasRequired(t => t.caseQuestion)
                .WithRequiredDependent()
                .Map(m => m.MapKey("question"));
        }
    }
}
