﻿using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM.Context;
using ORM.Entity;

namespace DAL
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository()
        {
            _context = new ApplicationDbContext();
        }

        public DalPost GetById(int key)
        {
            return _context.Posts.Find(key).ToDalPost();
        }

        public void Insert(DalPost entity)
        {
            _context.Posts.Add(entity.ToOrmPost());
            _context.SaveChanges();
        }

        public void Delete(DalPost entity)
        {
            var temp = _context.Posts.Find(entity.Id);
            _context.Posts.Remove(temp);
            _context.SaveChanges();
        }

        public void Update(DalPost entity)
        {
            var temp = _context.Posts.Find(entity.Id);
            temp = entity.ToOrmPost();
            _context.SaveChanges();
        }

        public IEnumerable<DalPost> GetAll(int skip = 0, int take = 10)
        {
            return _context.Posts.OrderByDescending(p => p.UploadDate).Skip(skip).Take(take).AsEnumerable()
                            .Select(p => p.ToDalPost());
        }

        public IEnumerable<DalPost> GetByTag(string tag, int skip = 0, int take = 10)
        {
            return _context.Posts.OrderByDescending(p => p.UploadDate).AsEnumerable().
                Select(p => p.ToDalPost()).
                Where(p => p.Tags.Contains(tag)).
                Skip(skip).Take(take);
        }

        public int CountByTag(string tag)
        {
            return _context.Tags.Count(t => t.Text.Contains(tag));
        }

        public int CountByUserId(int userId)
        {
            return _context.Posts.Count(p => p.UserId == userId);
        }

        public int CountAll()
        {
            return _context.Posts.Count();
        }

        public IEnumerable<DalPost> GetByUserId(int userId, int skip = 0, int take = 10)
        {
            return _context.Posts.OrderByDescending(p => p.UploadDate).Where(p => p.UserId == userId).Skip(skip).
                Take(take).AsEnumerable().Select(c => c.ToDalPost());
        }

        public void LikePost(int postId, int userId)
        {
            var temp = _context.Posts.Find(postId);
            temp.NumberOfLikes++;
            temp.UserLikesEntity.Add(new UserLikesEntity { UserLikesId = userId, PostId = postId });
            _context.SaveChanges();
        }

        public void DislikePost(int postId, int userId)
        {
            var temp = _context.Posts.Find(postId);
            temp.NumberOfLikes--;
            var ulTemp =
                temp.UserLikesEntity.FirstOrDefault(entity => entity.PostId == postId && entity.UserLikesId == userId);
            _context.UserLikes.Remove(ulTemp);
            _context.SaveChanges();
        }

        public IEnumerable<string> FindTag(string tag)
        {
            var s = _context.Posts.ToList().Where(p => p.Tags.Any(t => t.Text.StartsWith(tag))).Take(20).Select(p => p.Tags);

            var list = new List<string>();
            foreach (var arr in s)
            {
                foreach (var str in arr)
                {
                    if (str.Text.StartsWith(tag) && (!list.Contains(str.Text)))
                        list.Add(str.Text);
                }
            }

            return list;
        }
    }
}
