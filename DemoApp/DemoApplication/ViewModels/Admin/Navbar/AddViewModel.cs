using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class AddViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ToURL { get; set; }

        public bool IsMain { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public bool IsViewHeader { get; set; }
        [Required]
        public bool IsViewFooter { get; set; }
    }
}
