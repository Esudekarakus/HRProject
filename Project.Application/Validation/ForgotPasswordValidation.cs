using FluentValidation;
using Project.Application.Features.CQRS.Commands.AccountCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Validation
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordValidation()
        {
            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Parola boş geçilemez")
             .MinimumLength(8).WithMessage("Parola en az 8 karakter uzunluğunda olmalıdır")
             .MaximumLength(50).WithMessage("Parola en fazla 50 karakter uzunluğunda olabilir")
             .Must(BeAValidPassword).WithMessage("Parola en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir")
              .Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("E-posta boş geçilemez")
               .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz");
        }

        private bool BeAValidPassword(string password)
        {
            // Parolanın en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermesi gerektiğini kontrol eder
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(IsSpecialCharacter);
        }
        private bool IsSpecialCharacter(char c)
        {
            // Parolada özel karakter olup olmadığını kontrol eder
            return !char.IsLetterOrDigit(c);
        }

        
    }
}
