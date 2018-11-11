using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL
{
    public static class BllEntityMapper
    {

        //#region UserId
        //public static DalUser ToDalUser(this BllUser user)
        //{
        //    return new DalUser
        //    {
        //        PostId = user.PostId,
        //        Email = user.Email,
        //        Login = user.Login,
        //        Name = user.Name,
        //        Password = user.Password,
        //        Phone = user.Phone,
        //        ProfilePhoto = user.ProfilePhoto,
        //        Roles = user.Roles
        //    };
        //}

        //public static BllUser ToBllUser(this DalUser user)
        //{
        //    return new BllUser
        //    {
        //        PostId = user.PostId,
        //        Email = user.Email,
        //        Login = user.Login,
        //        Name = user.Name,
        //        Password = user.Password,
        //        Phone = user.Phone,
        //        ProfilePhoto = user.ProfilePhoto,
        //        Roles = user.Roles
        //    };
        //}
        //#endregion

        //#region Post
        //public static BllPost ToBllPost(this DalPost photo)
        //{
        //    return new BllPost
        //    {
        //        PostId = photo.PostId,
        //        Name = photo.Name,
        //        Description = photo.Description,
        //        Image = photo.Image,
        //        NumberOfLikes = photo.NumberOfLikes,
        //        Tags = photo.Tags,
        //        UploadDate = photo.UploadDate,
        //        UserId = photo.UserId.ToBllUser(),
        //        UserLikes = ToBllUserLikes(photo.UserLikes)
        //    };
        //}

        //public static DalPost ToDalPost(this BllPost photo)
        //{
        //    return new DalPost
        //    {
        //        PostId = photo.PostId,
        //        Name = photo.Name,
        //        Description = photo.Description,
        //        Image = photo.Image,
        //        NumberOfLikes = photo.NumberOfLikes,
        //        Tags = photo.Tags,
        //        UploadDate = photo.UploadDate,
        //        UserId = photo.UserId.ToDalUser(),
        //        UserLikes = ToDalUserLikes(photo.UserLikes)
        //    };
        //}
        //#endregion

        //#region UserLikes

        //public static IEnumerable<DalUserLikes> ToDalUserLikes(IEnumerable<BllUserLikes> bllUserLikes)
        //{
        //    return bllUserLikes.Select(b => new DalUserLikes
        //    {
        //        UserLikesEntityId = b.UserLikesEntityId,
        //        UserLikesId = b.UserLikesId,
        //        UserName = b.UserName
        //    }).ToList();
        //}

        //public static IEnumerable<BllUserLikes> ToBllUserLikes(IEnumerable<DalUserLikes> dalUserLikes)
        //{
        //    return dalUserLikes.Select(b => new BllUserLikes
        //    {
        //        UserLikesEntityId = b.UserLikesEntityId,
        //        UserLikesId = b.UserLikesId,
        //        UserName = b.UserName
        //    }).ToList();
        //}

        //#endregion

        //#region Comment
        //public static DalComment ToDalComment(this BllComment comment)
        //{
        //    return new DalComment
        //    {
        //        PostId = comment.PostId,
        //        UserId = comment.UserId.ToDalUser(),
        //        PostId = comment.PostId,
        //        Posted = comment.Posted,
        //        Text = comment.Text
        //    };
        //}

        //public static BllComment ToBllComment(this DalComment comment)
        //{
        //    return new BllComment
        //    {
        //        PostId = comment.PostId,
        //        UserId = comment.UserId.ToBllUser(),
        //        PostId = comment.PostId,
        //        Posted = comment.Posted,
        //        Text = comment.Text
        //    };
        //}
        //#endregion

        #region Pay
        public static BllPayment ToBllPayment(this DalPayment payment)
        {
            return new BllPayment
            {
                Age = payment.Age,
                Countries = payment.Countries,
                Language = payment.Language,
                Price = payment.Price,
                Sex = payment.Sex
            };
        }

        public static DalPayment ToDalPayment(this BllPayment payment)
        {
            return new DalPayment
            {
                Age = payment.Age,
                Countries = payment.Countries,
                Language = payment.Language,
                Price = payment.Price,
                Sex = payment.Sex
            };
        }
        #endregion
    }
}
