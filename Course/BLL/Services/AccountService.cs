using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public BllUser GetUserByLogin(string login)
        {
            return Mapper.CreateMap().Map<BllUser>(_userRepository.GetUserByLogin(login));
        }

        public BllUser GetUserById(int id)
        {
            return Mapper.CreateMap().Map<BllUser>(_userRepository.GetById(id));
        }

        public bool CheckIfUserExists(string login)
        {
            return _userRepository.CheckIfUserExists(login);
        }

        public void CreateUser(BllUser user)
        {
            _userRepository.Insert(Mapper.CreateMap().Map<DalUser>(user));
        }

        public void EditeUserPtofile(int userId, string newName, byte[] newProfile)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                _userRepository.ChangeName(userId, newName);
            }
            if (newProfile!=null & newProfile.Length!=0)
            {
                _userRepository.ChangeProfilePhoto(userId, newProfile);
            }
        }
    }
}
