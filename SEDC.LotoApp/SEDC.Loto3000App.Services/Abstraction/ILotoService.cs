using System;
using SEDC.Loto3000App.DTOs;

namespace SEDC.Loto3000App.Services.Abstraction
{
	public interface ILotoService
	{
		List<LotoDto> GetAllWinners(int userId);
		LotoDto GetById(int id);
		void AddWinner(AddLotoDto addLotoDto);
		void UpdateWinner(UpdateLotoDto updateLotoDto);
		void DeleteWinner(int id);
		
	}
}

