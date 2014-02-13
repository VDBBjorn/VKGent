using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class BoxMap : EntityTypeConfiguration<Box>
    {
        public BoxMap()
        {
            this.HasMany(t => t.questions)
                .WithRequired()
                .Map(m => m.MapKey("elementId"));
        }
    }
}
