using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testbga.Models
{
    public class ComponentMetadata
    {
    }
    [MetadataType(typeof(ComponentMetadata))]
    public partial class Component
    {
        [NotMapped]
        public string? Data { get; set; } = string.Empty;
        public Component Create(CustomContext db)
        {
            var type = Type.GetType(this.Name);

            dynamic json = JsonConvert.DeserializeObject(this.Data,type);
            Object x = Activator.CreateInstance(type);
            (x as Component).Name = this.Name;
            switch (this.Name)
            {
                case "Testbga.Models.TextBox":
                    (x as TextBox).Value = json.Value;
                    break;
            }

            Component buffer = (Component)json;
            
            db.Add(buffer);
            db.SaveChanges();
            return buffer;

        }

        

    }
    public class SuperComponent
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        public string? Value { get; set; }

        public virtual ICollection<SuperContaining> Containings { get; set; } = new List<SuperContaining>();

    }

    public class SuperContaining
    {
        public int Id { get; set; }

        public int? ContainerId { get; set; }

        public int? ComponentId { get; set; }

        public virtual SuperComponent? Component { get; set; }

        public virtual SuperComponent? Container { get; set; }

    }
}
