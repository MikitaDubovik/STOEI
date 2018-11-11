using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;
using ORM.Entity;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public DalUser GetById(int key)
        {
            var t = _context.Users.FirstOrDefault(u => u.UserId == key);
            var tt = Mapper.CreateMap().Map<DalUser>(_context.Users.FirstOrDefault(u => u.UserId == key));
            return Mapper.CreateMap().Map<DalUser>(_context.Users.FirstOrDefault(u => u.UserId == key));
        }

        public void Insert(DalUser entity)
        {
            var tempEntity = Mapper.CreateMap().Map<User>(entity);
            var temp = _context.Roles.FirstOrDefault(r => r.Name.Equals(tempEntity.Roles.Name));
            tempEntity.Roles = temp;
            _context.Users.Add(tempEntity);
            _context.SaveChanges();

        }

        public void Delete(DalUser entity)
        {
            _context.Users.Remove(Mapper.CreateMap().Map<User>(entity));
            _context.SaveChanges();
        }

        public void Update(DalUser entity)
        {
            var temp = _context.Users.Find(entity.UserId);
            temp = Mapper.CreateMap().Map<User>(entity);
            _context.SaveChanges();
        }

        public void ChangeName(int userId, string newName)
        {
            var temp = _context.Users.Find(userId);
            temp.Name = newName;
            _context.SaveChanges();
        }

        public DalUser GetUserByLogin(string login)
        {
            return Mapper.CreateMap().Map<DalUser>(_context.Users.FirstOrDefault(u => u.Login == login));
        }

        public bool CheckIfUserExists(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login) != null;
        }

        public void ChangeProfilePhoto(int userId, byte[] newProfilePhoto)
        {
            var temp = _context.Users.Find(userId);
            temp.ProfilePhoto = newProfilePhoto;
            _context.SaveChanges();
        }
    }
}
