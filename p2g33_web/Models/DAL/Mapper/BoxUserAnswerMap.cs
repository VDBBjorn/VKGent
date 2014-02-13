﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class BoxUserAnswerMap: EntityTypeConfiguration<BoxUserAnswer>
    {
        public BoxUserAnswerMap()
        {
            this.HasRequired(t => t.BoxQuestion)
                .WithMany()
                .HasForeignKey(t => t.BoxQuestionId);
        }
    }
}