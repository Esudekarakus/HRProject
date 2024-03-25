using FluentValidation;
using Project.Application.Features.CQRS.Commands.AccountCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Validation
{
    public class LoginValidation : AbstractValidator<LoginCommand>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Parola boş geçilemez");
             

              RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş geçilemez")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz");

        }

       
    }
}
