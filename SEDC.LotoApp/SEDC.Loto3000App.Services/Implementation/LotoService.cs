using System;
using SEDC.Loto3000App.DataAcces;
using SEDC.Loto3000App.Domain.Models;
using SEDC.Loto3000App.DTOs;
using SEDC.Loto3000App.Mappers;
using SEDC.Loto3000App.Services.Abstraction;

namespace SEDC.Loto3000App.Services.Implementation
{
	public class LotoService : ILotoService
	{
		private readonly IRepository<Loto> _lotoRepository;
		private readonly IRepository<User> _userRepository;

		public LotoService(IRepository<Loto> lotoRepository,
			               IRepository<User> userRepository)
		{
			_lotoRepository = lotoRepository;
			_userRepository = userRepository;

		}

        public void AddWinner(AddLotoDto addLotoDto)
        {
            var userDb = _userRepository.GetById(addLotoDto.UserId);

            if(userDb is null)
            {
                throw new Exception($"User with id {addLotoDto.UserId} does not exist");
            }

            if(addLotoDto.Numbers > 37)
            {
                throw new Exception("Numbers can not contain more the 37 numbers");
            }

            var newLotoDb = addLotoDto.ToLoto();

            _lotoRepository.Add(newLotoDb);
        }

        public void DeleteWinner(int id)
        {
            var lotoFromDb = _lotoRepository.GetById(id);
             if(lotoFromDb == null)
            {
                throw new Exception($"Winner with that id {id} does not exist");
            }

            _lotoRepository.Delete(lotoFromDb);
        }

        public List<LotoDto> GetAllWinners(int userId)
        {
            var lotofromDb = _lotoRepository.GetAll();
            return lotofromDb.Where(loto => loto.UserId == userId)
                             .Select(loto => loto.ToLotoDto()).ToList();
        }

        public LotoDto GetById(int id)
        {
            var lotoFromDb = _lotoRepository.GetById(id);
            if(lotoFromDb is null)
            {
                throw new Exception($"Winner with that id {id} does not exist");
            }
            return lotoFromDb.ToLotoDto();
        }

        public void UpdateWinner(UpdateLotoDto updateLotoDto)
        {
            var lotoFromdb = _lotoRepository.GetById(updateLotoDto.Id);

            if(lotoFromdb is null)
            {
                throw new Exception($"Winner with that {updateLotoDto.Id} does not exist");

            }
            var userDb = _userRepository.GetById(updateLotoDto.Id);
            if(userDb is null)
            {
                throw new Exception($"User with that id{updateLotoDto.UserId} does not exist");
            }

            if (updateLotoDto.Numbers > 37)
            {
                throw new Exception("Numbers can not be more then 37");
            }

            lotoFromdb.Numbers = updateLotoDto.Numbers;
            lotoFromdb.Prize = updateLotoDto.Prize;
            lotoFromdb.Session = updateLotoDto.Session;
            lotoFromdb.UserId = updateLotoDto.UserId;
            lotoFromdb.User = userDb;


            _lotoRepository.Update(lotoFromdb);

            
        }
    }
}

