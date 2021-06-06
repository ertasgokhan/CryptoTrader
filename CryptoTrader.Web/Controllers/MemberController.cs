using CryptoTrader.Web.Models;
using CryptoTrader.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        protected UserManager<AppUser> userManager { get; }
        protected RoleManager<AppRole> roleManager { get; }

        public MemberController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View(roleManager.Roles.ToList());
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole();
                appRole.Name = roleViewModel.Name;

                IdentityResult result = await roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    TempData["AddRoleSucceeded"] = true;
                    roleViewModel = new RoleViewModel();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(roleViewModel);
        }
    }
}
