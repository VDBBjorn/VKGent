using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class StatementGameQuestionAnswerMap : EntityTypeConfiguration<StatementGameAnswer>
    {
        public StatementGameQuestionAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.statementGameAnswerId);

            // Properties

            this.Property(t => t.statementGameAnswerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.answer)
                .HasMaxLength(255);

            this.Property(t => t.statementGameQuestionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("StatementGameQuestionAnswer");
            this.Property(t => t.answer).HasColumnName("answers");
            this.Property(t => t.statementGameQuestionId).HasColumnName("statementGameQuestionId_fk");

            // Relationships

        }
    }
}
