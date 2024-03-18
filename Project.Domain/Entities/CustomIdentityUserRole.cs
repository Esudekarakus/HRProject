using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class CustomIdentityUserRole : IdentityUserRole<string>
    {

        public override string UserId { get; set; }
        public override string RoleId { get; set; }
    }
}
