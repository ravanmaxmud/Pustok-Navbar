using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class AddViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
   
        public string ToURL { get; set; }

        public bool IsMain { get; set; }
        
        public int Order { get; set; }

        [Required]
        public bool IsViewHeader { get; set; }
        [Required]
        public bool IsViewFooter { get; set; }
    }
}
