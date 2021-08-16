using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Domain
{
    public class User: IdentityUser
    {
        public DateTime UserBirthday { get; set; }
    }
}
