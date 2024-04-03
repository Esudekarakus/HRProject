using Project.Domain.Enum;

namespace Project.WebApi.DTOs.AccountDTOs
{
    public class AppUserDetailsDTO
    {
        public int PersonalId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthOfPlace { get; set; }
        public string Address { get; set; }
        public string IdendificationNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public Status? Status { get; set; }
        public string? ImageName { get; set; }
        public string ImageSrc { get; set; }
        //public IFormFile? ImageFile { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public int? OffDays { get; set; }
        public string Profession { get; set; }
        public string PrivateMail { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
