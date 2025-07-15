using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Testbga.Models
{
    public class TextboxMetadata
    {
        public virtual Component? IdNavigation { get; set; } 
    }
    [MetadataType(typeof(TextboxMetadata))]
    public partial class TextBox:Component
    {
    }
  
}
    