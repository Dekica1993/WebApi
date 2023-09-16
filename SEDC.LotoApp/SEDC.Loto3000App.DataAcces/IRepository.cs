using System;
namespace SEDC.Loto3000App.DataAcces
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		T GetById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		
	}
}

