using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Testbga.Models
{
    public class ContainerMetadata
    {
    }
    public partial class Container : Component
    {

    }

    public partial class Page : Container
    {
        
    }

    public partial class Section : Container
    {
        [Column("ID")]
        public int SectionID { get; set; }
    }

    //[MetadataType(typeof(ContainerMetadata))]
    //public partial class Container
    //{
    //    public Container Create (CustomContext db)
    //    {
            

    //        db.Components.Add(this);
    //        db.SaveChanges();
    //        return this;
    //    }
    //}

}
