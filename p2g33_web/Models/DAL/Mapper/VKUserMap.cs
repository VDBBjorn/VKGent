using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class VKUserMap : EntityTypeConfiguration<VKUser>
    {
        public VKUserMap()
        {
            // Primary Key
            this.HasKey(t => t.email);

            // Properties
            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.phoneNumber)
                .HasMaxLength(255);

           

            // Table & Column Mappings
            this.ToTable("VKUser");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.internalUser).HasColumnName("internal");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.guest).HasColumnName("guest");
            this.Property(t => t.creationDate).HasColumnName("creationDate");

            //Relationships
            this.HasMany(p => p.LearningProcesses)
                .WithMany()
                .Map(map =>
                    {
                        map.MapLeftKey("email_fk");
                        map.MapRightKey("learningProcessCode_fk");
                        map.ToTable("Cursist");
                    });

            this.HasMany(m => m.LearningProcessesExternal)
                .WithMany()
                .Map(map =>
                    {
                        map.MapRightKey("learningProcessCode_fk");
                        map.MapLeftKey("email_fk");
                        map.ToTable("ExternalCooperator");
                    });

            this.HasMany(m => m.LearningProcessesCreator)
                .WithRequired(m => m.creator)
                .Map(m => m.MapKey("creator"));

            this.HasMany(m => m.UserAnswers)
                .WithRequired()
                .HasForeignKey(m => m.Email);

        }
    }
}
