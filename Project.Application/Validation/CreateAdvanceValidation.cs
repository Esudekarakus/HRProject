using FluentValidation;
using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Validation
{
    public class CreateAdvanceValidation : AbstractValidator<CreateAdvanceCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateAdvanceValidation(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Para birimi belirtilmelidir");
            RuleFor(x => x.AdvanceType).NotEmpty().WithMessage("Avans türü belirtilmelidir");
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Miktar pozitif olmalıdır")
                .Must(BeLessThanOrEqualToMaxSalary).WithMessage("Miktar, çalışanın maksimum maaşından 3 kat daha az veya eşit olmalıdır");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Çalışan ID'si belirtilmelidir");
        }
         private bool BeLessThanOrEqualToMaxSalary(CreateAdvanceCommand command, double amount)
        {
            // Çalışanın maksimum maaşını almak için gerekli kodu burada kullanın.
            double maxSalary = _employeeRepository.GetSalaryByEmployeeId(command.EmployeeId);
            // Miktarın maksimum maaşın 3 katından küçük veya eşit olup olmadığını kontrol edin
            return amount <= maxSalary * 3;
        }

        
    }
}
