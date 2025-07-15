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
            var containings = this.Containings.ToList();
            this.Containings.Clear(); // Clear existing containings to avoid duplicates
            Component Page = this.Create(db);

            foreach (Containing containing in containings)
            {
                Component child = containing.Component.Create(db);

                Containing dd = new Containing();
                dd.ContainerId = Page.Id;
                dd.ComponentId = child.Id;
                dd.Create(db);
            }

            return this;
        }
    }
}
