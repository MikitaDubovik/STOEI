using System;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;

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
            return _context.Users.FirstOrDefault(u => u.UserId == key).ToDalUser();
        }

        public void Insert(DalUser entity)
        {
            var tempEntity = entity.ToOrmUser();
            var temp = _context.Roles.FirstOrDefault(r => r.Name.Equals(tempEntity.Roles.Name));
            tempEntity.Roles = temp;
            _context.Users.Add(tempEntity);
            _context.SaveChanges();

        }

        public void Delete(DalUser entity)
        {
            _context.Users.Remove(entity.ToOrmUser());
            _context.SaveChanges();
        }

        public void Update(DalUser entity)
        {
            var temp = _context.Users.Find(entity.Id);
            temp = entity.ToOrmUser();
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
            return _context.Users.FirstOrDefault(u => u.Login == login).ToDalUser();
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
