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


        // ==== Data Protection Techniques ======
        // Data protection techniques are methods used to safeguard sensitive information from unauthorized access, disclosure, alteration, or destruction.

        // 1. Hashing
        // Hashing is a one-way process that converts data into a fixed-size string of characters, which is typically a sequence of numbers and letters.
        // one-way means that once data is hashed, it cannot be converted back to its original form.
        // algorithms: SHA-256, SHA-1, MD5
        // example: Password Hashing => hashing password can not be reversed to get the original password
        // Identity password is also hashed using a hashing algorithm before storing to aspnetusers table

        // Incription
        // Encryption is a two-way process that transforms data into a coded format using an algorithm and a key.
        // two-way means that encrypted data can be decrypted back to its original form using the appropriate key.
        // algorithms: AES, RSA, DES
        // AES stand for Advanced Encryption Standard, is a symmetric encryption algorithm widely used across the globe to secure data.
        // RSA stand for Rivest-Shamir-Adleman, is an asymmetric encryption algorithm used for secure data transmission.
        // DES stand for Data Encryption Standard, is a symmetric-key algorithm for the encryption of digital data.
        // example: Data Transmission => encrypting data during transmission to prevent unauthorized access
        // Identity uses encryption to protect sensitive data such as security stamps and tokens.

        // Cipher Algorithms: is used by encryption techniques to convert plain text into cipher text and vice versa.
        // examples: AES (Advanced Encryption Standard), RSA (Rivest-Shamir-Adleman), DES (Data Encryption Standard)


        // Masking
        // Data masking is the process of hiding original data with modified content (characters or other data).
        // masking is typically used to protect sensitive data in non-production environments or when displaying data to unauthorized users.
        // algorithms: Static Masking, Dynamic Masking, On-the-fly Masking
        // example: Credit Card Numbers => displaying only the last four digits of a credit card number while masking the rest
        // Identity does not have built-in data masking features, but it can be implemented at the application level.


        // Tokenization
        // Salting
        // Obfuscation
        // Anonymization

    }
}
