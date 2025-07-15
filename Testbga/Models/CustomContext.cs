using Microsoft.EntityFrameworkCore;

namespace Testbga.Models
{
    public partial class CustomContext: TestbgContext //CustomContext เป็นคลาส context ย่อย ที่สืบทอดจาก TestBgContext
    {
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

            modelBuilder.Entity<Component>().UseTptMappingStrategy().ToTable("Component");
            //TPT หมายความว่า: class แม่ (Component) และ class ลูก (เช่น Container, Banner) จะมี table แยกของตัวเอง และใช้ JOIN เพื่อดึงข้อมูล
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<TextBox>().ToTable("TextBox");
            modelBuilder.Entity<Container>().UseTptMappingStrategy().ToTable("Container");
            modelBuilder.Entity<Container>().Ignore(p => p.Page);
            modelBuilder.Entity<Container>().Ignore(p => p.Section);
            modelBuilder.Entity<Page>().ToTable("Page");
            modelBuilder.Entity<Section>().ToTable("Section");

            modelBuilder.Entity<Containing>(entity =>
            {
                entity.Ignore(C => C.Container);

                entity.HasOne(d => d.Component).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Component");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
