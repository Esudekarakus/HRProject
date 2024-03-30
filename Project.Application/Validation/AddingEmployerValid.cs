using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Commands.EmployerCommands;

namespace Project.Application.Validation
{
    public class AddingEmployerValid : AbstractValidator<CreateEmployerCommand>
    {
        public AddingEmployerValid()
        {
            //RuleFor(x => x.ImageURL).NotNull().WithMessage("Lütfen bir resim dosyası seçin.");

            RuleFor(dto => dto.Department)
                .NotEmpty().WithMessage("Departman alanı boş geçilemez!");

            RuleFor(x => x.Profession)
                .NotEmpty().WithMessage("Meslek adı boş bırakılamaz!");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz!")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır!")
                .MinimumLength(2).WithMessage("İsim En Az 3 Haneli Olmalı!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz!")
                .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olmalıdır!")
                .MinimumLength(3).WithMessage("Soyisim Alanı En Az 3 Haneli Olmalı!");

            RuleFor(x => x.MiddleName).MaximumLength(50).WithMessage("Orta ad en fazla 50 karakter olmalıdır!");

            RuleFor(x => x.SecondLastName).MaximumLength(50).WithMessage("İkinci soyad en fazla 50 karakter olmalıdır!");

            RuleFor(x => x.DateOfStart).NotEmpty().WithMessage("Başlangıç tarihi boş bırakılamaz.");

            // RuleFor(x => x.IdentificationNumber)
            //     .NotEmpty().WithMessage("Kimlik numarası boş bırakılamaz.")
            //     .Must(BeValidTurkishIdentificationNumber).WithMessage("Geçersiz bir TC kimlik numarası girdiniz.");


            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Maaş alanı boş bırakılamaz.")
                .GreaterThanOrEqualTo(17000).WithMessage("Maaş Asgari Ücretten Az Olamaz!");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Adres Tanımlaması En Fazla 200 Karakter Olmalı!")
                .MinimumLength(20).WithMessage("Adres Tanımlama En Az 20 Karakter Olmalı!");

            //RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş bırakılamaz.");

            //RuleFor(x => x.County).NotEmpty().WithMessage("İlçe boş bırakılamaz.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.");

            RuleFor(x => x.BirthOfPlace).NotEmpty().WithMessage("Doğum yeri boş bırakılamaz.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");
            // .Matches(@"^05[0-9]{9}$").WithMessage("Geçerli bir telefon numarası girin.");





        }

        private bool BeValidTurkishIdentificationNumber(string identificationNumber)
        {
            // TC kimlik numarası 11 karakter olmalı
            if (string.IsNullOrEmpty(identificationNumber) || identificationNumber.Length != 11)
            {
                return false;
            }

            // TC kimlik numarası sadece rakamlardan oluşmalıdır
            foreach (char c in identificationNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // İlk rakam sıfır olamaz
            if (identificationNumber[0] == '0')
            {
                return false;
            }

            // İlk 9 rakamın toplamının 10. rakama modu 10 olmalı
            int sumFirstNineDigits = 0;
            for (int i = 0; i < 9; i++)
            {
                sumFirstNineDigits += int.Parse(identificationNumber[i].ToString());
            }
            int tenthDigit = int.Parse(identificationNumber[9].ToString());
            if (sumFirstNineDigits % 10 != tenthDigit)
            {
                return false;
            }

            // İlk 10 rakamın toplamının modu 10. rakamla aynı olmalıdır
            int sumFirstTenDigits = 0;
            for (int i = 0; i < 10; i++)
            {
                sumFirstTenDigits += int.Parse(identificationNumber[i].ToString());
            }
            int eleventhDigit = int.Parse(identificationNumber[10].ToString());
            if (sumFirstTenDigits % 10 != eleventhDigit)
            {
                return false;
            }

            
            return true;
        }


    }
}
