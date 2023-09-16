using System;
using SEDC.Loto3000App.Domain.Models;

namespace SEDC.Loto3000App.DataAcces.EntityImplementation
{
	public class UserRepository : IRepository<User>
	{

		private readonly LotoAppDbContext _lotoAppDbContext;

	    public UserRepository(LotoAppDbContext lotoAppDbContext)
		{
			_lotoAppDbContext = lotoAppDbContext;
		}

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _lotoAppDbContext.Users
                                 .SingleOrDefault(user => user.Id == id);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

