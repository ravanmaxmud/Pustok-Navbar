using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        [Required]
        public int Order { get; set; }

        [Required]
        public int NavbarId { get; set; }
        public List<NavbarListItemViewModel>? Navbar { get; set; }
    }
}
