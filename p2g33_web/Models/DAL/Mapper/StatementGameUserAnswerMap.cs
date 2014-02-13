using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class StatementGameUserAnswerMap : EntityTypeConfiguration<StatementGameUserAnswer>
    {
        public StatementGameUserAnswerMap()
        {
            this.HasRequired(t => t.StatementGameAnswer)
                .WithMany()
                .HasForeignKey(t => t.StatementGameAnswerId);

            this.HasRequired(t => t.StatementGameQuestion)
                .WithMany()
                .HasForeignKey(t => t.StatementGameQuestionId);
        }
    }
}