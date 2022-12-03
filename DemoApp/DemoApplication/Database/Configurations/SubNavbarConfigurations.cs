using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DemoApplication.Database.Models;

namespace DemoApplication.Database.Configurations
{
    public class SubNavbarConfigurations : IEntityTypeConfiguration<SubNavbar>
    {
        public void Configure(EntityTypeBuilder<SubNavbar> builder)
        {
            builder
              .HasOne(b => b.Navbar)
              .WithMany(b => b.SubNavbars)
              .HasForeignKey(b => b.NavbarId);
        }
    }
}
