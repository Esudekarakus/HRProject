namespace Project.WebApi.Models.AccountDTOs
{
    public class CreateAdminDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
        
        public string Name { get; set; }
        public string  PhoneNumber { get; set; }
    }
}