using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Navbar : BaseEntity
    {

        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool IsMain { get; set; }
        public bool IsViewHeader { get; set; }
        public bool IsViewFooter { get; set; }

        public List<SubNavbar>? SubNavbars { get; set; }
    }
}
