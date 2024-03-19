using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class JwtOptions
    {
        public string secureKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; } 
    }
}
