using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.AccountCommands
{
    public class ForgotPasswordCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string VerificationCode { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
