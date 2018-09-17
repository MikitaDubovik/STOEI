using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository repository, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _postRepository = repository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public BllUser GetAuthorById(int id)
        {
            return _userRepository.GetById(id).ToBllUser();
        }

        public IEnumerable<BllPost> GetAll(int skip, int take)
        {
            return _postRepository.GetAll(skip, take).Select(p => p.ToBllPost());
        }

        public void Add(BllPost photo)
        {
            _postRepository.Insert(photo.ToDalPost());
        }

        public IEnumerable<string> FindTags(string tag)
        {
            return _postRepository.FindTag(tag);
        }

        public int CountByTag(string tag)
        {
            if (tag == string.Empty)
                return _postRepository.CountAll();
            return _postRepository.CountByTag(tag);
        }

        public IEnumerable<BllPost> GetByTag(string tag, int skip, int take)
        {
            if (tag == string.Empty)
            {
                return _postRepository.GetAll(skip, take).Select(p => p.ToBllPost());
            }

            return _postRepository.GetByTag(tag, skip, take).Select(p => p.ToBllPost());
        }

        public BllPost GetById(int id)
        {
            return _postRepository.GetById(id).ToBllPost();
        }

        public IEnumerable<BllPost> GetByUserId(int userId, int skip, int take)
        {
            return _postRepository.GetByUserId(userId, skip, take).Select(p => p.ToBllPost());
        }

        public int CountByUserId(int id)
        {
            return _postRepository.CountByUserId(id);
        }

        public void LikePost(int userId, int postId)
        {
            _postRepository.LikePost(postId, userId);
        }

        public void DislikePost(int userId, int postId)
        {
            _postRepository.DislikePost(postId, userId);
        }

        public void AddComment(BllComment comment)
        {
           _commentRepository.Insert(comment.ToDalComment());
        }

        public int CountCommentByPostId(int postId)
        {
            return _commentRepository.CountByPostId(postId);
        }

        public IEnumerable<BllComment> GetCommentsByPostId(int postId, int skip, int take)
        {
            return _commentRepository.GetByPostId(postId, skip, take).Select(p => p.ToBllComment());
        }

        public void Delete(int postId)
        {
            _commentRepository.DeleteAllCommentsToPost(postId);
            _postRepository.Delete(_postRepository.GetById(postId));
        }
    }
}
