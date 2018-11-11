//using System.Collections.Generic;
//using System.Linq;
//using DAL.Interface.DTO;
//using ORM.Entity;

//namespace DAL
//{
//    public static class DalEntityMapper
//    {
//        #region UserId
//        public static DalUser ToDalUser(this User user)
//        {
//            return new DalUser
//            {
//                PostId = user.UserId,
//                Email = user.Email,
//                Login = user.Login,
//                Name = user.Name,
//                Password = user.Password,
//                Phone = user.Phone,
//                ProfilePhoto = user.ProfilePhoto,
//                Roles = ToDalRole(user.Roles)
//            };
//        }

//        public static User ToOrmUser(this DalUser user)
//        {
//            return new User
//            {
//                UserId = user.PostId,
//                Email = user.Email,
//                Login = user.Login,
//                Name = user.Name,
//                Password = user.Password,
//                Phone = user.Phone,
//                ProfilePhoto = user.ProfilePhoto,
//                Roles = ToOrmRole(user.Roles)
//            };
//        }
//        #endregion

//        #region Roles

//        public static string ToDalRole(this Role role)
//        {
//            return role?.Name ?? "UserId";
//        }

//        public static Role ToOrmRole(this string role)
//        {
//            return new Role { Name = role };
//        }

//        #endregion

//        #region Post
//        public static DalPost ToDalPost(this Post post)
//        {
//            return new DalPost
//            {
//                PostId = post.PostId,
//                Name = post.Name,
//                Description = post.Description,
//                Image = post.Image,
//                NumberOfLikes = post.NumberOfLikes,
//                Tags = ToDalTag(post.Tags),
//                UploadDate = post.UploadDate,
//                User = post.User.ToDalUser(),
//                UserLikes = ToDalUserLikes(post.UserLikesEntity)
//            };
//        }

//        public static Post ToOrmPost(this DalPost photo)
//        {
//            return new Post
//            {
//                PostId = photo.PostId,
//                Name = photo.Name,
//                Description = photo.Description,
//                Image = photo.Image,
//                NumberOfLikes = photo.NumberOfLikes,
//                Tags = ToOrmTag(photo.Tags),
//                UploadDate = photo.UploadDate,
//                UserId = photo.User.PostId,
//                UserLikesEntity = ToOrmUserLikes(photo.UserLikes)
//            };
//        }
//        #endregion

//        #region Tags

//        public static IEnumerable<string> ToDalTag(this IEnumerable<Tag> tags)
//        {
//            return tags?.Select(t => t.Text).ToList() ?? new List<string>();
//        }

//        public static List<Tag> ToOrmTag(this IEnumerable<string> userLikes)
//        {
//            return userLikes.Select(ul => new Tag { Text = ul }).ToList();
//        }

//        #endregion

//        #region UserLikes

//        public static IEnumerable<DalUserLikes> ToDalUserLikes(this IEnumerable<UserLikesEntity> userLikes)
//        {
//            return userLikes?.Select(t => new DalUserLikes { UserLikesId = t.UserLikesId, UserLikesEntityId = t.UserLikesEntityId }).ToList();
//        }

//        public static List<UserLikesEntity> ToOrmUserLikes(this IEnumerable<DalUserLikes> userLikes)
//        {
//            return userLikes.Select(ul => new UserLikesEntity { UserLikesId = ul.UserLikesId, UserLikesEntityId = ul.UserLikesEntityId }).ToList();
//        }

//        #endregion

//        #region Comment
//        public static DalComment ToDalComment(this Comment comment)
//        {
//            return new DalComment
//            {
//                PostId = comment.CommentId,
//                UserId = comment.UserId,
//                PostId = comment.PostId,
//                Posted = comment.Posted,
//                Text = comment.Text
//            };
//        }

//        public static Comment ToOrmComment(this DalComment comment)
//        {
//            return new Comment
//            {
//                CommentId = comment.PostId,
//                UserId = comment.UserId,
//                PostId = comment.PostId,
//                Posted = comment.Posted,
//                Text = comment.Text
//            };
//        }
//        #endregion
//    }
//}
