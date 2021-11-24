using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }//add FullName  в table AspNetUser
    }
}
