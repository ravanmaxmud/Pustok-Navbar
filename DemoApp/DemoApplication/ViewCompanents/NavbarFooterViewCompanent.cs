using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewCompanents
{

    [ViewComponent(Name = "NavbarFooter")]
    public class NavbarFooterViewCompanent : ViewComponent
    {
        private readonly DataContext _dataContext;

        public NavbarFooterViewCompanent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _dataContext.Navbars.Include(n => n.SubNavbars.OrderBy(sn=> sn.Order)).Where(n => n.IsViewFooter == true).ToList();
            return View("~/Views/Shared/Companents/NavbarFooter.cshtml", model);
        }

    }
}
