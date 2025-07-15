using System.ComponentModel.DataAnnotations;
namespace Testbga.Models
{
    public class ContainingMetadata
    {
    }
    [MetadataType(typeof(ContainingMetadata))]
    public partial class Containing
    {
        public Containing Create(CustomContext db)
        {
            db.Containings.Add(this);
            db.SaveChanges();
            return this;
        }
    }
}
