using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        //==== (JWT) json web token ======
        // 1. Login token
        // login token is generated when user successfully logs in

        // 2. Authentication token
        // authentication token is generated for each request to access protected resources

        // 3. Refresh Token 
        // refresh token is used to obtain a new authentication token when the current one expires
        // refresh token has a longer expiry time compared to authentication token
        // refresh token is securely stored and transmitted to prevent unauthorized access

        
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }


        

    }
}
