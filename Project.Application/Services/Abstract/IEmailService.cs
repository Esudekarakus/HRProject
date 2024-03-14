using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.Abstract
{
    public interface IEmailService
    {
        public void SendCompanyMailToCreatedEmployee(string mail, string password, string privateMailTosend);
    }
}
