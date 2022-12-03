using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DemoApplication.Database.Models;

namespace DemoApplication.Database.Configurations
{
    public class NavbarConfigurations : IEntityTypeConfiguration<Navbar>
    {
        public void Configure(EntityTypeBuilder<Navbar> builder)
        {
            builder
                  .ToTable("Navbar");
        }
    }
}
