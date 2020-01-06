using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels.Account
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
