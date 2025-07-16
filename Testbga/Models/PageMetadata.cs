using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testbga.Models
{
    public class PageMetadata
    {
    }
    [MetadataType(typeof(PageMetadata))]
    public partial class Page
    {
        public Component CreatePage (CustomContext db)
        {
            List<Containing> containings = this.Containings.ToList();
            this.Containings.Clear();

            Component Page = this.Create(db);
            this.Id = Page.Id;
                

            foreach (Containing containing in containings)
            {
                Component child = containing.Component.Create(db);

                Containing dd = new Containing();
                dd.ContainerId = Page.Id;
                dd.ComponentId = child.Id;
                dd.Create(db);

                if (child.Name == "Testbga.Models.Section")
                {
                    Section section = (Section)child;
                    section.Containings = containing.Component.Containings.ToList() ?? new List<Containing>();
                    section.CreateSectionContining(db, child);
                }
            }
     

             
            return this;
        }
    }
}
