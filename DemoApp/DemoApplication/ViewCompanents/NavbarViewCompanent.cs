using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.ViewCompanents
{
    [ViewComponent(Name ="Navbar")]
    public class NavbarViewCompanent :ViewComponent
    {
        private readonly DataContext _dataContext;

        public NavbarViewCompanent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = 
                _dataContext.Navbars.Include
                (n => n.SubNavbars.OrderBy
                (sn=> sn.Order)).Where(n => n.IsViewHeader == true).OrderBy(n=>n.Order).ToList();
           return View("~/Views/Shared/Companents/Navbar.cshtml",model);
        }

    }
}
