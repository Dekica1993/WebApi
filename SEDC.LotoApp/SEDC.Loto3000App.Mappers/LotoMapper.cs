using System;
using SEDC.Loto3000App.Domain.Models;
using SEDC.Loto3000App.DTOs;

namespace SEDC.Loto3000App.Mappers
{
	public static class LotoMapper
	{
		public static Loto ToLoto (this AddLotoDto addLotoDto)
		{
			return new Loto
			{
				Numbers = addLotoDto.Numbers,
				Prize = addLotoDto.Prize,
				Session = addLotoDto.Session,
				UserId = addLotoDto.UserId

			};

		}

		public static LotoDto ToLotoDto(this Loto loto)
		{
			var lotoDto = new LotoDto
			{
				Numbers = loto.Numbers,
				Prize = loto.Prize,
				Session = loto.Session

			};
			 if(loto.User is not null)
			{
				lotoDto.UserFullName = $"{loto.User.FirstName} {loto.User.LastName}";

			};

			return lotoDto;
		}
		
	}
}

