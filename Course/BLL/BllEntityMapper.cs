using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL
{
    public static class BllEntityMapper
    {

        #region User
        public static DalUser ToDalUser(this BllUser user)
        {
            return new DalUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                ProfilePhoto = user.ProfilePhoto,
                Roles = user.Roles
            };
        }

        public static BllUser ToBllUser(this DalUser user)
        {
            return new BllUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                ProfilePhoto = user.ProfilePhoto,
                Roles = user.Roles
            };
        }
        #endregion


        #region Post
        public static BllPost ToBllPost(this DalPost photo)
        {
            return new BllPost
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Image = photo.Image,
                NumberOfLikes = photo.NumberOfLikes,
                Tags = photo.Tags,
                UploadDate = photo.UploadDate,
                User = photo.User.ToBllUser(),
                UserLikes = ToBllUserLikes(photo.UserLikes)
            };
        }

        public static DalPost ToDalPost(this BllPost photo)
        {
            return new DalPost
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Image = photo.Image,
                NumberOfLikes = photo.NumberOfLikes,
                Tags = photo.Tags,
                UploadDate = photo.UploadDate,
                User = photo.User.ToDalUser(),
                UserLikes = ToDalUserLikes(photo.UserLikes)
            };
        }
        #endregion

        #region UserLikes

        public static IEnumerable<DalUserLikes> ToDalUserLikes(IEnumerable<BllUserLikes> bllUserLikes)
        {
            return bllUserLikes.Select(b => new DalUserLikes
            {
                UserLikesEntityId = b.UserLikesEntityId,
                UserLikesId = b.UserLikesId,
                UserName = b.UserName
            }).ToList();
        }

        public static IEnumerable<BllUserLikes> ToBllUserLikes(IEnumerable<DalUserLikes> dalUserLikes)
        {
            return dalUserLikes.Select(b => new BllUserLikes
            {
                UserLikesEntityId = b.UserLikesEntityId,
                UserLikesId = b.UserLikesId,
                UserName = b.UserName
            }).ToList();
        }

        #endregion

        #region Comment
        public static DalComment ToDalComment(this BllComment comment)
        {
            return new DalComment
            {
                Id = comment.Id,
                User = comment.User.ToDalUser(),
                PostId = comment.PostId,
                Posted = comment.Posted,
                Text = comment.Text
            };
        }

        public static BllComment ToBllComment(this DalComment comment)
        {
            return new BllComment
            {
                Id = comment.Id,
                User = comment.User.ToBllUser(),
                PostId = comment.PostId,
                Posted = comment.Posted,
                Text = comment.Text
            };
        }
        #endregion

    }
}
