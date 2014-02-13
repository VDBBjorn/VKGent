using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class BoxQuestionMap : EntityTypeConfiguration<BoxQuestion>
    {
        public BoxQuestionMap()
        {
            this.HasKey(t => t.boxQuestionId);
            this.Property(t => t.question).IsRequired().HasColumnName("question");
            this.Property(t => t.boxQuestionId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("boxQuestionId");

            this.ToTable("BoxQuestion");


        }
    }
}
