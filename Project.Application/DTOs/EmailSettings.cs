using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class EmailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Display { get; set; }
        public int Port { get; set; }
    }
}
