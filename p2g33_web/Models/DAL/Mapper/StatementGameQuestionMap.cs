using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class StatementGameQuestionMap : EntityTypeConfiguration<StatementGameQuestion>
    {
        public StatementGameQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.statementGameQuestionId);

            // Properties
            this.Property(t => t.statementGameQuestionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.question)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("StatementGameQuestion");
            this.Property(t => t.statementGameQuestionId).HasColumnName("statementGameQuestionId");
            this.Property(t => t.question).HasColumnName("question");

            // Relationships
            this.HasMany(t => t.StatementGameQuestionAnswers)
                .WithRequired()
                .HasForeignKey(t => t.statementGameQuestionId);
        }
    }
}
