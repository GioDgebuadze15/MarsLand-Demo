using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace WebSite.Models
{
    public class ExternalLoginModel
    {
        public List<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
