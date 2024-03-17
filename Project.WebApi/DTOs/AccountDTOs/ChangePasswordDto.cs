namespace Project.WebApi.Models.AccountDTOs
{
    public class ChangePasswordDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
