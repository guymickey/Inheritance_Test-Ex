using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testbga.Models
{
    public class DependentPageMetadata
    {
    }
    [MetadataType(typeof(DependentPageMetadata))]
    public partial class DependentPage
    {
        [NotMapped]
        public Component? Component { get; set; }
        public DependentPage Create(CustomContext db)
        {
            if (Component != null)
            {
                Page page = new Page
                {
                    Name = Component.Name,
                    Data = Component.Data,
                    Containings = Component.Containings
                };
                page.CreatePage(db);
                PageId = page.Id;
            }
            db.DependentPages.Add(this);
           
            return this;
        }
    }
}
