using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class CaseAnswerMap : EntityTypeConfiguration<CaseAnswer>
    {
        public CaseAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.caseAnswerId);

            // Properties
            this.Property(t => t.caseAnswerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.answer)
                .HasMaxLength(255);

            this.Property(t => t.feedback)
                .HasMaxLength(255);

            this.Property(t => t.nextQuestionId)
                .IsOptional();

            // Table & Column Mappings
            this.ToTable("CaseAnswer");
            this.Property(t => t.caseAnswerId).HasColumnName("caseAnswerId");
            this.Property(t => t.answer).HasColumnName("answer");
            this.Property(t => t.feedback).HasColumnName("feedback");
            this.Property(t => t.nextQuestionId).HasColumnName("nextQuestion");

            // Relationships
            this.HasOptional(t => t.nextQuestion)
                .WithMany()
                .HasForeignKey(t => t.nextQuestionId);
        }
    }
}
