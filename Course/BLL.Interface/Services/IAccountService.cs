using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAccountService
    {
        BllUser GetUserByLogin(string login);
        BllUser GetUserById(int id);
        bool CheckIfUserExists(string login);
        void CreateUser(BllUser user);
        void EditeUserPtofile(int userId, string newName, byte[] newProfile);
    }
}
