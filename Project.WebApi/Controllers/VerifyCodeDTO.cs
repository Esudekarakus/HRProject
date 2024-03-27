namespace Project.WebApi.Controllers
{
    public class VerifyCodeDTO
    {
        public string inputCode { get; set; }
        public string privateMail { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
