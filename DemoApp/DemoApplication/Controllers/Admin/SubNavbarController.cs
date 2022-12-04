using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.SubNavbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/subNav")]
    public class SubNavbarController : Controller
    {

        private readonly DataContext _dataContext;

        public SubNavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region List
        [HttpGet("list", Name = "admin-subNav-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dataContext.SubNavbar
                .Select
                (s => new SubNavListItemViewModel
                (s.Id, s.Name, s.ToURL, s.Order, s.Navbar.Name))
                .ToListAsync();
            return View("~/Views/Admin/SubNavbar/List.cshtml", model);
        }
        #endregion

        #region Add
        [HttpGet("add", Name = "admin-subNav-add")]
        public async Task<IActionResult> Add()
        {
            var model = new AddViewModel
            {
                Navbar = await _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToListAsync()
            };
            return View("~/Views/Admin/SubNavbar/add.cshtml", model);
        }

        [HttpPost("add", Name = "admin-subNav-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/SubNavbar/add.cshtml", model);
            }
            if (!_dataContext.Navbars.Any(a=>a.Id == model.NavbarId))
            {
                ModelState.AddModelError(String.Empty,"Navbar Is Not Found");
                return View("~/Views/Admin/SubNavbar/add.cshtml", model);
            }
            if (_dataContext.SubNavbar.Any(a => a.Order == model.Order))
            {
                var navModel = new AddViewModel
                {
                    Navbar = await _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToListAsync()
                };
                ModelState.AddModelError(String.Empty, "Order is not be the same");
                return View("~/Views/Admin/SubNavbar/add.cshtml", navModel);
            }
            var subNavbar = new SubNavbar
            {
                Name = model.Name,
                ToURL = model.ToURL,    
                NavbarId = model.NavbarId,
                Order = model.Order,

            };
            await _dataContext.SubNavbar.AddAsync(subNavbar);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-subNav-list");
        }
        #endregion


        #region Update
        [HttpGet("update/{id}", Name = "admin-subNav-update")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var subNav = await _dataContext.SubNavbar.Include(s => s.Navbar).FirstOrDefaultAsync(s => s.Id == id);
            if (subNav == null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                Id = subNav.Id,
                Name = subNav.Name,
                ToURL = subNav.ToURL,
                Order = subNav.Order,
                NavbarId = subNav.NavbarId,
                Navbar = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToList()
            };
            return View("~/Views/Admin/SubNavbar/update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-subNav-update")]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {
            var subNav = await _dataContext.SubNavbar.Include(s => s.Navbar).FirstOrDefaultAsync(s => s.Id == model.Id);
            if (subNav is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/SubNavbar/update.cshtml", model);
            }
            if (!_dataContext.Navbars.Any(a => a.Id == model.NavbarId))
            {
                ModelState.AddModelError(String.Empty, "Navbar Is Not Found");
                return View("~/Views/Admin/SubNavbar/update.cshtml", model);
            }
            if (_dataContext.SubNavbar.Any(a => a.Order == model.Order))
            {
                var navModel = new AddViewModel
                {
                    Navbar = await _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToListAsync()
                };
                ModelState.AddModelError(String.Empty, "Order is not be the same");
                return View("~/Views/Admin/SubNavbar/add.cshtml", navModel);
            }

            subNav.Name = model.Name;
            subNav.Order = model.Order;
            subNav.NavbarId = model.NavbarId;
            subNav.ToURL = model.ToURL;

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-subNav-list");
        }
        #endregion

        #region Delete
        [HttpPost("delete/{id}", Name = "admin-subNav-delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var subNav = await _dataContext.SubNavbar.Include(s => s.Navbar).FirstOrDefaultAsync(s => s.Id == id);
            if (subNav is null)
            {
                return NotFound();
            }
             _dataContext.SubNavbar.Remove(subNav);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-subNav-list");
        }
        #endregion
    }
}
