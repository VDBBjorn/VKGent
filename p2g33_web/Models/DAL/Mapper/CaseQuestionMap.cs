using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class CaseQuestionMap : EntityTypeConfiguration<CaseQuestion>
    {
        public CaseQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.caseQuestionId);

            // Properties
            this.Property(t => t.caseQuestionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.consideration)
                .HasMaxLength(255);

            this.Property(t => t.question)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CaseQuestion");
            this.Property(t => t.caseQuestionId).HasColumnName("caseQuestionId");
            this.Property(t => t.consideration).HasColumnName("consideration");
            this.Property(t => t.question).HasColumnName("question");

            //Relationships
            this.HasMany(t => t.CaseAnswers)
                .WithRequired()
                .Map(m => m.MapKey("caseQuestionId"));
        }
    }
}
