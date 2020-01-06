using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Project.Data;
using Project.ViewModels.Account;


namespace Project.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> _userManger;
        public SignInManager<IdentityUser> _signInManager; 

        public AccountController(UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _userManger.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }

        public IActionResult LogIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,true,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                
                ModelState.AddModelError("", result.ToString());
                
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}