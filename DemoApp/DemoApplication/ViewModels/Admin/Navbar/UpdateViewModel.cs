namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; }
        public bool IsViewHeader { get; set; }
        public bool IsViewFooter { get; set; }
    }
}
