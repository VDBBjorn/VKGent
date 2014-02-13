using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class CaseUserAnswerMap : EntityTypeConfiguration<CaseUserAnswer>
    {
        public CaseUserAnswerMap()
        {
            this.HasRequired(t => t.CaseQuestion)
                .WithMany()
                .HasForeignKey(t => t.CaseQuestionId);

            this.HasRequired(t => t.CaseAnswer)
                .WithMany()
                .HasForeignKey(t => t.CaseAnswerId);
        }
    }
}