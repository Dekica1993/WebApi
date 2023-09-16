using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SEDC.Loto3000App.DataAcces.Abstraction;
using SEDC.Loto3000App.DataAcces.EntityImplementation;
using SEDC.Loto3000App.DTOs;
using SEDC.Loto3000App.Services.Abstraction;
using SEDC.Loto3000App.CryptoService;
using SEDC.Loto3000App.Domain.Models;

namespace SEDC.Loto3000App.Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;

		}

        public string LoginUser(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrEmpty(loginUserDto.UserName) ||
                string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new Exception("Username and password are required fields!");
            }

            var userFromDb = _userRepository.LoginUser(loginUserDto.UserName, StringHasher.Hash(loginUserDto.Password));

            if (userFromDb == null)
            {
                throw new Exception("User not found!");
            }

            //Generate JWT Token
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("Our very secret secret key");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(3),
                //signature configuration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("userFullName", $"{userFromDb.FirstName} {userFromDb.LastName}"),
                        new Claim("userId", $"{userFromDb.Id}"),
                        new Claim(ClaimTypes.Name, userFromDb.UserName)
                    }
                )
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            //1. validation
            ValidateUser(registerUserDto);

            //2. Hash password
            var passwordHash = StringHasher.Hash(registerUserDto.Password);

            //3. create new user
            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                UserName = registerUserDto.Username,
                Age = registerUserDto.Age,
                Password = passwordHash
            };

            _userRepository.Add(user);
        }

        private void ValidateUser(RegisterUserDto registerUserDto)
        {
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new Exception("Password must match!");
            }

            if (string.IsNullOrEmpty(registerUserDto.Username) ||
                string.IsNullOrEmpty(registerUserDto.Password) ||
                string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new Exception("Username and password are required fields!");
            }

            if (registerUserDto.Username.Length > 30)
            {
                throw new Exception("Username: Maximum length for username is 30 characters");
            }

            if (registerUserDto.FirstName.Length > 50)
            {
                throw new Exception("Maximum length for FirstName is 50 characters");
            }

            if (registerUserDto.LastName.Length > 50)
            {
                throw new Exception("Maximum length for LastName is 50 characters");
            }

            var userFromDb = _userRepository.GetUserByUsername(registerUserDto.Username);
            if (userFromDb != null)
            {
                throw new Exception($"The username {registerUserDto.Username} is already in use!");
            }
        }
    }
}

