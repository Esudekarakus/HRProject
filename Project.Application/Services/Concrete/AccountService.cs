using Project.Application.Services.Abstract;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Identity;
using Project.Application.UnitOfWork.Abstract;
using System.Security.Policy;

namespace Project.Application.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, SignInManager<AppUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.signInManager = signInManager;
        }

        public async Task<bool> SignInForAppUser(string inputMail ,string inputPassword)
        {

            var User = await userManager.FindByEmailAsync(inputMail);

            if (User != null)
            {

                var result = await signInManager.PasswordSignInAsync(User, inputPassword, false, false);
                if (result.Succeeded)
                    return true;

                return false;
            }
            return false;
        }

     

        public async Task<bool> UpdatePasswordAsync(string email, string password, string confirmPassword)
        {
            AppUser user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                if (password == confirmPassword)
                {
                    var passwordValidator = new PasswordValidator<AppUser>();
                    var result = await passwordValidator.ValidateAsync(userManager, user, password);

                    if (result.Succeeded)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);
                        var resetResult = await userManager.ResetPasswordAsync(user, token, password);

                        if (resetResult.Succeeded)
                            return true;
                        return false;
                    }
                    return false;

                }
                return false;
            }
            return false;

        }
    }
}
