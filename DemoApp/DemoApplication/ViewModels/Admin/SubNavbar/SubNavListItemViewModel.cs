namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class SubNavListItemViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public string Navbar { get; set; }
        public SubNavListItemViewModel(int id, string name, string toURL, int order, string navbar)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            Navbar = navbar;
        }





    }
}
