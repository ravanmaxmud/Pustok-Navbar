namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class navListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool IsMain { get; set; }
        public bool IsViewHeader { get; set; }
        public bool IsViewFooter { get; set; }

        public navListViewModel(int id,string name, string toURL, int order, bool isMain, bool isViewHeader, bool isViewFooter)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            IsMain = isMain;
            IsViewHeader = isViewHeader;
            IsViewFooter = isViewFooter;
        }

    }
}
