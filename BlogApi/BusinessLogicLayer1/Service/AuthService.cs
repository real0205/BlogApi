using Azure;
using BusinessLogicLayer.MapperMethods;
using DataAccessLayer.Data;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.DTO.AuthDTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models.BlogModels;
using DomainLayer.Models.JwtSigningKey;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserMapper _userMapper;
        public AuthService(IConfiguration configuration, IUnitOfWork unitOfWork, UserMapper userMapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
        }

        public LoginResponse LoginAsync(LoginDTO loginDto)
        {

            User? user = _unitOfWork.userRepository.GetAllUsers()
                .FirstOrDefault((u => u.Email.Equals(loginDto.Email)));


            // If the user does not exist, return a 401 Unauthorized response
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }

            // At this point, authentication is successful. Proceed to generate a JWT token.
            var token = GenerateJwtTokenAsync(user);

            UserDto UserData = _userMapper.MapUserToUserDto(user);
            //return "Credentials Correct";
            return new LoginResponse()
            {
                userData = UserData,
                Message = "Credentials Correct",
                Token = token
            };
        }


        private string GenerateJwtTokenAsync(User user)
        {
            // Retrieve the active signing key from the SigningKeys table
            SigningKey signingKey = _unitOfWork.signingKeyRepository.GetActiveSiginingKey();

            // If no active signing key is found, throw an exception
            if (signingKey == null)
            {
                throw new Exception("No active signing key available.");
            }

            // Convert the Base64-encoded private key string back to a byte array
            var privateKeyBytes = Convert.FromBase64String(signingKey.PrivateKey);

            // Create a new RSA instance for cryptographic operations
            var rsa = RSA.Create();

            // Import the RSA private key into the RSA instance
            rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

            // Create a new RsaSecurityKey using the RSA instance
            var rsaSecurityKey = new RsaSecurityKey(rsa)
            {
                // Assign the Key ID to link the JWT with the correct public key
                KeyId = signingKey.KeyId
            };

            // Define the signing credentials using the RSA security key and specifying the algorithm
            var creds = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);

            // Initialize a list of claims to include in the JWT
            var claims = new List<Claim>
            {
                // Subject (sub) claim with the user's ID
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

                // JWT ID (jti) claim with a unique identifier for the token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // Name claim with the user's first name
                new Claim(ClaimTypes.Name, user.Username),

                // NameIdentifier claim with the user's email
                new Claim(ClaimTypes.NameIdentifier, user.Email),

                // Email claim with the user's email
                new Claim(ClaimTypes.Email, user.Email),

                // Role claim with user role
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Define the JWT token's properties, including issuer, audience, claims, expiration, and signing credentials
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], // The token issuer, typically your application's URL
                                                      //audience: client.ClientURL, // The intended recipient of the token, typically the client's URL
                claims: claims, // The list of claims to include in the token
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time set to 1 hour from now
                signingCredentials: creds // The credentials used to sign the token
            );

            // Create a JWT token handler to serialize the token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Serialize the token to a string
            var token = tokenHandler.WriteToken(tokenDescriptor);

            // Return the serialized JWT token
            return token;
        }

    }
}
