using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Loto3000App.DataAcces;

namespace SEDC.Loto3000App.Helpers
{
	public  static class DependencyInjectionHelper
	{
		public static void InjectDbContext(this IServiceCollection services, string connectionstring)
		{
			services.AddDbContext<LotoAppDbContext>(options =>
			  options.UseSqlServer(connectionstring));
		}
		
	}
}

