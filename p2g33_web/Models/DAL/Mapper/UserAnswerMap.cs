using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class UserAnswerMap:EntityTypeConfiguration<UserAnswer>
    {
        public UserAnswerMap()
        {
            this.ToTable("UserAnswer");
            this.HasKey(m => m.UserAnswerId);
            this.Property(m => m.UserAnswerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Map<StatementGameUserAnswer>(map =>
                {
                    map.Requires("userAnswerType").HasValue("StatementGame");
                    map.Properties(m => new
                        {
                            m.UserAnswerId,
                            m.Email,
                            m.StatementGameAnswerId,
                            m.StatementGameQuestionId,
                            m.LearningProcessCode,
                            m.ElementId
                        });
                    map.ToTable("UserAnswer");
                })
                .Map<BoxUserAnswer>(map =>
                    {
                        map.Requires("userAnswerType").HasValue("Box");
                        map.Properties(m => new
                            {
                                m.UserAnswerId,
                                m.Email,
                                m.ElementId,
                                m.LearningProcessCode,
                                m.BoxQuestionId,
                                m.BoxAnswer,
                                m.BoxMotivation
                            });
                        map.ToTable("UserAnswer");
                    })
                    .Map<CaseUserAnswer>(map =>
                        {
                            map.Requires("userAnswerType").HasValue("Case");
                            map.Properties(m => new
                                {
                                    m.Email,
                                    m.ElementId,
                                    m.LearningProcessCode,
                                    m.CaseAnswerId,
                                    m.CaseQuestionId
                                });
                            map.ToTable("UserAnswer");
                        });

            this.HasRequired(t => t.LearningProcess)
                .WithMany()
                .HasForeignKey(t => t.LearningProcessCode);

            this.HasRequired(t => t.Element)
                .WithMany()
                .HasForeignKey(t => t.ElementId);
        }
    }
}