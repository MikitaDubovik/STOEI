using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;

namespace DAL
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository()
        {
            _context = new ApplicationDbContext();
        }

        public DalComment GetById(int key)
        {
            return _context.Comments.Find(key).ToDalComment();
        }

        public void Insert(DalComment entity)
        {
            _context.Comments.Add(entity.ToOrmComment());
            _context.SaveChanges();
        }

        public void Delete(DalComment entity)
        {
            var temp = _context.Comments.Find(entity.Id);
            _context.Comments.Remove(temp);
            _context.SaveChanges();
        }

        public void Update(DalComment entity)
        {
            var temp = _context.Comments.Find(entity.Id);
            temp = entity.ToOrmComment();
            _context.SaveChanges();
        }

        public IEnumerable<DalComment> GetByPostId(int postId, int skip = 0, int take = 10)
        {
            return _context.Comments.OrderByDescending(p => p.Posted).Where(p => p.PostId == postId).Skip(skip).
                Take(take).AsEnumerable().Select(c => c.ToDalComment());
        }

        public void DeleteAllCommentsToPost(int postId)
        {
            _context.Comments.RemoveRange(_context.Comments.Where(i => i.PostId == postId));
            _context.SaveChanges();
        }

        public int CountByPostId(int postId)
        {
            return _context.Comments.Count(i => i.PostId == postId);
        }
    }
}
