using System;
using SEDC.Loto3000App.Domain.Models;

namespace SEDC.Loto3000App.DataAcces.Abstraction
{
	public interface IUserRepository : IRepository<User>
	{
        User GetUserByUsername(string username);
        User LoginUser(string username, string hashedPassword);


    }
}

