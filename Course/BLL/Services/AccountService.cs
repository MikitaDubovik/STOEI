using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;

        public AccountService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public BllUser GetUserByLogin(string login)
        {
            return Mapper.CreateMap().Map<BllUser>(userRepository.GetUserByLogin(login));
        }

        public BllUser GetUserById(int id)
        {
            return Mapper.CreateMap().Map<BllUser>(userRepository.GetById(id));
        }

        public bool CheckIfUserExists(string login)
        {
            return userRepository.CheckIfUserExists(login);
        }

        public void CreateUser(BllUser user)
        {
            userRepository.Insert(Mapper.CreateMap().Map<DalUser>(user));
        }

        public void EditeUserPtofile(int userId, string newName, byte[] newProfile)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                userRepository.ChangeName(userId, newName);
            }
            if (newProfile!=null & newProfile.Length!=0)
            {
                userRepository.ChangeProfilePhoto(userId, newProfile);
            }
        }
    }
}
