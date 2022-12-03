using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Navbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/nav")]
    public class NavbarController : Controller
    {
        private readonly DataContext _dataContext;

        public NavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #region List

        [HttpGet("list", Name = "admin-nav-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Navbars
                .Select
                (n => new navListViewModel
                (n.Id,n.Name, n.ToURL, n.Order, n.IsMain, n.IsViewHeader, n.IsViewFooter))
                .ToListAsync();

            return View("~/Views/Admin/Navbar/List.cshtml", model);
        }

        #endregion


        #region Add

        [HttpGet("add", Name = "admin-nav-add")]
        public IActionResult Add()
        {
            return View("~/Views/Admin/Navbar/Add.cshtml");
        }

        [HttpPost("add", Name = "admin-nav-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Navbar/Add.cshtml", model);
            }

            if (_dataContext.Navbars.Any(a => a.Order == model.Order))
            {
                ModelState.AddModelError(String.Empty, "Author is not found");
                return View("~/Views/Admin/Navbar/Add.cshtml", model);
            }

            //if (model.IsViewHeader)
            //{
            //    var navBar2 = new Navbar
            //    {
            //        Name = model.Name,
            //        ToURL = model.ToURL,
            //        Order = model.Order,
            //        IsViewFooter = model.IsViewFooter,
            //        IsViewHeader = model.IsViewHeader,
            //    };

            //    await _dataContext.Navbars.AddAsync(navBar2);
            //    await _dataContext.SaveChangesAsync();
            //}

            var navBar = new Navbar
            {
                Name = model.Name,
                ToURL = model.ToURL,
                IsMain = model.IsMain,
                Order = model.Order,
                IsViewFooter = model.IsViewFooter,
                IsViewHeader = model.IsViewHeader,
            };

            await _dataContext.Navbars.AddAsync(navBar);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-nav-list");
        }


        #endregion

        #region Update

        [HttpGet("update/{id}", Name = "admin-nav-update")]
        public async Task<IActionResult> Update([FromRoute]int id) 
        {
            var navItem = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id);
            if (navItem is null)
            {
                return NotFound();
            }
            var model = new UpdateViewModel
            {
                Id = navItem.Id,
                Name = navItem.Name,
                IsMain = navItem.IsMain,
                ToURL = navItem.ToURL,
                Order = navItem.Order,
                IsViewFooter=navItem.IsViewFooter,
                IsViewHeader=navItem.IsViewHeader,
            };

            return View("~/Views/Admin/Navbar/Update.cshtml",model);
        }
        [HttpPost("update/{id}", Name = "admin-nav-update")]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {
            var navItem = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (navItem is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Navbar/Update.cshtml", model);
            }


            navItem.Name = model.Name;
            navItem.ToURL = model.ToURL;
            navItem.Order = model.Order;
            navItem.IsViewFooter = model.IsViewFooter;
            navItem.IsViewHeader = model.IsViewHeader;

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-nav-list");
        }
        #endregion

        #region Delete
        [HttpPost("delete/{id}", Name = "admin-nav-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var navItem = await _dataContext.Navbars.FirstOrDefaultAsync(b => b.Id == id);
            if (navItem is null)
            {
                return NotFound();
            }

             _dataContext.Navbars.Remove(navItem);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-nav-list");
        }

        #endregion
    }
}
