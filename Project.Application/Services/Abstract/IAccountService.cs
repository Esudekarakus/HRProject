using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.Abstract
{
    public interface IAccountService
    {
        public Task<bool> SignInForAppUser(string mail,string inputPassword);
        public  Task<bool> IfPasswordMatches(string password, string confirmPassword);
        Task<bool> UpdatePasswordAsync(string email, string password, string confirmPassword);
        public Task<bool> IsUserValid(string email);
        public Task<AppUser> getAppUserDetailsIncludePersonelDetails(AppUser appUser);
    }
}
