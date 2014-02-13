using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL.Mapper
{
    public class ElementMap : EntityTypeConfiguration<Element>
    {
        public ElementMap()
        {
            this.ToTable("Element");
            this.Map<Document>(map =>
                    {
                        map.Requires("elementType").HasValue("Document");
                        map.Properties(m => new
                            {
                                m.elementId,
                                m.availableFrom,
                                m.availableUntil,
                                m.description,
                                m.keyWords,
                                m.targetGroup,
                                m.title,
                                m.fileLocation
                            });
                        map.ToTable("Element");
                    })
                .Map<Case>(map =>
                    {
                        map.Requires("elementType").HasValue("Case");
                        map.Properties(m => new 
                            {
                                m.elementId,
                                m.availableFrom,
                                m.availableUntil,
                                m.description,
                                m.keyWords,
                                m.targetGroup,
                                m.title,
                                m.situation,
                                m.movieFilePath
                            });
                        map.ToTable("Element");
                    })
                .Map<Box>(map =>
                    {
                        map.Requires("elementType").HasValue("Box");
                        map.Properties(m => new
                            {
                                m.elementId,
                                m.availableFrom,
                                m.availableUntil,
                                m.description,
                                m.keyWords,
                                m.targetGroup,
                                m.title,
                                m.theme
                            });
                        map.ToTable("Element");
                    })
                .Map<StatementGame>(map =>
                    {
                        map.Requires("elementType").HasValue("StatementGame");
                        map.Properties(m => new
                            {
                                m.elementId,
                                m.availableFrom,
                                m.availableUntil,
                                m.description,
                                m.keyWords,
                                m.targetGroup,
                                m.title
                            });
                        map.ToTable("Element");
                      });
        }
    }
}
