using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Testbga.Models
{
    public class EventMetadata
    {
    }
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {
        public Event Create(CustomContext db)
        {
            foreach (var dp in this.DependentPages)
            {
                dp.Create(db);
            }
            db.Events.Add(this);
            
            return this;
        }
    }
}
