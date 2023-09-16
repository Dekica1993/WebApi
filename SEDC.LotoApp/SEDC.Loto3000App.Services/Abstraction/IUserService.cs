using System;
using SEDC.Loto3000App.DTOs;

namespace SEDC.Loto3000App.Services.Abstraction
{
	public interface IUserService
	{
		void RegisterUser(RegisterUserDto registerUserDto);

		string LoginUser(LoginUserDto loginUserDto);
		
	}
}

