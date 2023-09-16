using System;
namespace SEDC.Loto3000App.Domain.Models
{
	public class User : BaseEntity
	{
        public string UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public List<Loto> Lotos { get; set; }

    }
}

