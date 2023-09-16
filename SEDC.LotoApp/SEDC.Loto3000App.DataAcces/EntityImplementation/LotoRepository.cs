using System;
using Microsoft.EntityFrameworkCore;
using SEDC.Loto3000App.Domain.Models;

namespace SEDC.Loto3000App.DataAcces.EntityImplementation
{
	public class LotoRepository : IRepository<Loto>
	{
		private readonly LotoAppDbContext _lotoAppDbContext;

		public LotoRepository(LotoAppDbContext lotoAppDbContext)
		{
			_lotoAppDbContext = lotoAppDbContext;

		}

        public void Add(Loto entity)
        {
            _lotoAppDbContext.Lotos.Add(entity);
            _lotoAppDbContext.SaveChanges();
        }

        public void Delete(Loto entity)
        {
            _lotoAppDbContext.Lotos.Remove(entity);
            _lotoAppDbContext.SaveChanges();
        }

        public List<Loto> GetAll()
        {
            return _lotoAppDbContext.Lotos
                 .Include(x => x.User).ToList();
        }

        public Loto GetById(int id)
        {
            return _lotoAppDbContext.Lotos
                .Include(x => x.User)
                .SingleOrDefault(loto => loto.Id == id);
        }

        public void Update(Loto entity)
        {
            _lotoAppDbContext.Lotos.Update(entity);
            _lotoAppDbContext.SaveChanges();
        }
    }
}

