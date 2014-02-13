using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class EvaluationMap : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationMap()
        {
            this.ToTable("Evaluation");
            this.HasKey(t => t.EvaluationId);
            this.Property(t => t.EvaluationId).HasColumnName("EvaluationId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Email).HasMaxLength(255).HasColumnName("Email");
            this.Property(t => t.LearningProcessCode).HasMaxLength(10).HasColumnName("LearningProcessCode");
            this.Property(t => t.BackgroundInformation).HasColumnName("BackgroundInformation");
            this.Property(t => t.UsefulBackgroundInformation).HasColumnName("UsefulBackgroundInformation");
            this.Property(t => t.PracticeExamples).HasColumnName("PracticeExamples");
            this.Property(t => t.UsefulPracticeExamples).HasColumnName("UsefulPracticeExamples");
            this.Property(t => t.ContentExpectation).HasColumnName("ContentExpectation");
            this.Property(t => t.PreperationLearningPlatform).HasColumnName("PreperationLearningPlatform");
            this.Property(t => t.PresentationLearningPlatform).HasColumnName("PresentationLearningPlatform");
            this.Property(t => t.ContentLearningPlatform).HasColumnName("ContentLearningPlatform");
            this.Property(t => t.UsefulLearningPlatform).HasColumnName("UsefulLearningPlatform");
            this.Property(t => t.ClearInformation).HasColumnName("ClearInformation");
            this.Property(t => t.ClearPresentation).HasColumnName("ClearPresentation");
            this.Property(t => t.QuestionsMentor).HasColumnName("QuestionsMentor");
            this.Property(t => t.FormationManner).HasColumnName("FormationManner");
            this.Property(t => t.RemarksFormation).HasMaxLength(255).HasColumnName("RemarksFormation");
            this.Property(t => t.RemarksLearningPlatform).HasMaxLength(255).HasColumnName("RemarksLearningPlatform");
            this.Property(t => t.RemarksMentor).HasMaxLength(255).HasColumnName("RemarksMentor");
            this.Property(t => t.GeneralRemark).HasMaxLength(255).HasColumnName("GeneralRemark");
            this.Property(t => t.MissedInFormation).HasMaxLength(255).HasColumnName("MissedInFormation");
        }
    }
}