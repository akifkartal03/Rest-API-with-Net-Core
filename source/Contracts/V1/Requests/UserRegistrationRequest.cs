using System;
using System.ComponentModel.DataAnnotations;

namespace netflixAPI.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public DateTime UserBirthday { get; set; }


    }
}