using Microsoft.AspNetCore.Mvc;

namespace Project.WebApi.Models.AccountDTOs
{
    public class EmailDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
