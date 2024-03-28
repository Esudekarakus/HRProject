using Project.Application.Services.Abstract;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.UnitOfWork.Abstract;
using System.Security.Policy;
using Project.Domain.Entities;

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

                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(User, inputPassword, false, false);
                if (result.Succeeded)
                    return true;

                return false;
            }
            return false;
        }

        public async Task<bool> IsUserValid(string email)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            return true;
        }
        public async Task<bool>IfPasswordMatches(string password, string confirmPassword)
        {
            if((password !=null && confirmPassword!=null)&& password ==confirmPassword)
            {

                return true;
            }
            return false;
        }
        public async Task<bool> UpdatePasswordAsync(string email, string password, string confirmPassword)
        {
            try
            {
                AppUser user = await userManager.FindByEmailAsync(email);


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
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<AppUser> getAppUserDetailsIncludePersonelDetails(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        //public async Task<AppUser> getAppUserDetailsIncludePersonalDetails(AppUser appUser)
        //{
        //    await userManager.
        //}
    }
}
