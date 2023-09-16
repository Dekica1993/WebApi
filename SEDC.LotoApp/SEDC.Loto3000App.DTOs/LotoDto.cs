using System;
using SEDC.Loto3000App.Domain.Enums;

namespace SEDC.Loto3000App.DTOs
{
	public class LotoDto
	{
		public int Numbers { get; set; }

		public Prize Prize { get; set; }

		public Session Session { get; set; }

		public string UserFullName { get; set; }
	}
}

