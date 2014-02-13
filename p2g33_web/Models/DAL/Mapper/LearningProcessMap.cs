using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using p2g33_web.Models.DAL.Mapper;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class LearningProcessMap : EntityTypeConfiguration<LearningProcess>
    {
        public LearningProcessMap()
        {
            this.HasKey(p => p.learningProcessCode);

            this.Property(p => p.learningProcessCode).IsRequired();
            this.Property(p => p.availableFrom);
            this.Property(p => p.availableUntil);
            this.Property(p => p.startDateLife);
            this.Property(p => p.targetGroup);
            this.Property(p => p.title).IsRequired();
            this.Property(p => p.description).IsRequired();

            this.HasMany(m => m.Elements)
                .WithMany()
                .Map(map =>
                    {
                        map.MapLeftKey("learningProcessCode_fk");
                        map.MapRightKey("element_fk");
                        map.ToTable("TrajectElement");
                    });

            this.ToTable("LearningProcess");
        }
    }
}
