using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Project.Controllers
{
    public class AccountRoleController : Controller
    {
        public AccountRoleController(IdentityRole<IdentityUser> identityRole, RoleManager<IdentityUser> roleManager)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}