using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class StatementGameMap : EntityTypeConfiguration<StatementGame>
    {
        public StatementGameMap()
        {
            this.HasMany(t => t.StatementGameQuestions)
                .WithRequired()
                .Map(m => m.MapKey("elementId"));
        }
    }
}