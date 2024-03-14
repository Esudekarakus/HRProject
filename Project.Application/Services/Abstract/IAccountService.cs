using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.Abstract
{
    public interface IAccountService
    {
        public Task<bool> SignInForAppUser(string mail);
        Task<bool> UpdatePasswordAsync(string email, string password, string confirmPassword);
    }
}
