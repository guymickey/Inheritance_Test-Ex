using System.ComponentModel.DataAnnotations;

namespace Testbga.Models
{
    public class SectionMetadata
    {
    }
    [MetadataType(typeof(SectionMetadata))]
    public partial class Section 
    {
        public void CreateSectionContining(CustomContext db, Component parentSectionComponent)
        {
            if (this.Containings == null || !this.Containings.Any())
                return;

            foreach (Containing subContaining in this.Containings)
            {
                Component child = subContaining.Component.Create(db);

                Containing containing = new Containing
                {
                    ContainerId = parentSectionComponent.Id,
                    ComponentId = child.Id
                };

                containing.Create(db);

                // ✅ ถ้า child เป็น Section → recursive สร้างต่อ
                if (child.Name == "Testbga.Models.Section")
                {
                    Section nestedSection = (Section)child;
                    nestedSection.Containings = subContaining.Component.Containings?.ToList() ?? new List<Containing>();
                    nestedSection.CreateSectionContining(db, child); // 👈 เรียกซ้ำ
                }
            }
        }


    }
}

