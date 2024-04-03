using Microsoft.AspNetCore.Http;
using Project.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Domain.Entities
{
    public class Employer : BaseEntity
    {
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? SecondLastName { get; set; }

        [StringLength(11)]
        public string IdentityNumber { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Status Status { get; set; }
        public string Department { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public string Profession { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public Company? Company { get; set; }
        public int? OffDays { get; set; }
        public int? CompanyId { get; set; }
        public string PrivateMail { get; set; }

        public string Email
        {
            get
            {

                string email = $"{LastName?.ToLower()}{Name.ToLower()}@bilgeadamboost.com";
                return email;
            }
        }

        private string ToEnglishCharacters(string text)
        {
            // Türkçe karakterlerin İngilizce karşılıklarını tutan bir sözlük
            Dictionary<char, string> turkishToEnglish = new Dictionary<char, string>
                             {
            { 'ç', "c" },
        { 'ğ', "g" },
        { 'ı', "i" },
        { 'ö', "o" },
        { 'ş', "s" },
        { 'ü', "u" },
        { 'Ç', "C" },
        { 'Ğ', "G" },
        { 'İ', "I" },
        { 'Ö', "O" },
        { 'Ş', "S" },
        { 'Ü', "U" }
    };

            StringBuilder englishText = new StringBuilder();
            foreach (char c in text)
            {
                if (turkishToEnglish.ContainsKey(c))
                {
                    englishText.Append(turkishToEnglish[c]);
                }
                else
                {
                    englishText.Append(c);
                }
            }

            return englishText.ToString();
        }



    }
}
