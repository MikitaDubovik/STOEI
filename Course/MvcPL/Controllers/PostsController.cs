using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure;
using MvcPL.Models;
using MvcPL.Models.Pagination;

namespace MvcPL.Controllers
{
    public class PostsController : Controller
    {
        public const int ImagesOnPage = 6;
        public const int CommentOnPage = 3;

        private readonly IPostService _postService;
        private readonly IAccountService _accountService;

        public PostsController(IPostService postService, IAccountService accountService)
        {
            _postService = postService;
            _accountService = accountService;
        }

        public ActionResult Index(int page = 1)
        {
            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = ImagesOnPage,
                TotalItems = _postService.CountByTag(string.Empty),
                UrlPart = Url.Action("LoadMore", "Posts", new { tag = "" })
            };

            IEnumerable<int> photosIds = _postService.GetAll(0, pageInfo.PageSize)
                .Select(p => p.Id);

            var photos = new List<ImageViewModel>(photosIds.Count());
            photos.AddRange(photosIds.Select(id => new ImageViewModel
            {
                ImageUrl = ToImageUrl(id),
                ImageDetailsUrl = ToImageDetailsUrl(id)
            }));

            return View(new PaginationViewModel<ImageViewModel> { Items = photos, PageInfo = pageInfo });
        }

        public ActionResult Find(string term)
        {
            IEnumerable<string> tags = _postService.FindTags(term);

            var projection = from t in tags
                             select new
                             {
                                 label = t,
                                 value = t
                             };
            if (Request.IsAjaxRequest())
            {
                return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
            }
            return View("Index");
        }

        public ActionResult Search(string tag = "", int page = 1)
        {
            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = ImagesOnPage,
                TotalItems = _postService.CountByTag(tag),
                UrlPart = Url.Action("LoadMore", "Posts", new { tag })
            };

            var photosIds = _postService.GetByTag(tag, pageInfo.Skip, pageInfo.PageSize)
                .Select(p => p.Id);
            var photos = new List<ImageViewModel>(photosIds.Count());
            photos.AddRange(photosIds.Select(id => new ImageViewModel
            {
                ImageUrl = ToImageUrl(id),
                ImageDetailsUrl = ToImageDetailsUrl(id)
            }));

            var pagedPosts =
                new PaginationViewModel<ImageViewModel> { PageInfo = pageInfo, Items = photos };

            return Json(pagedPosts, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LoadMore(string tag = "", int page = 1)
        {
            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = ImagesOnPage,
                TotalItems = _postService.CountByTag(tag),
                UrlPart = Url.Action("LoadMore", "Posts", new { tag })
            };

            var photosIds = _postService.GetByTag(tag, pageInfo.Skip, pageInfo.PageSize)
                .Select(p => p.Id);

            var photos = new List<ImageViewModel>(photosIds.Count());
            photos.AddRange(photosIds.Select(id => new ImageViewModel
            {
                ImageUrl = ToImageUrl(id),
                ImageDetailsUrl = ToImageDetailsUrl(id)
            }));

            var pagedPosts =
                new PaginationViewModel<ImageViewModel> { PageInfo = pageInfo, Items = photos };

            return Json(pagedPosts, JsonRequestBehavior.AllowGet);

        }

        private string ToImageUrl(int id)
        {
            return Url.Action("ShowImage", "Posts", new { id });
        }

        private string ToImageDetailsUrl(int id)
        {
            return Url.Action("PostDetails", "Posts", new { id });
        }


        public ActionResult ShowImage(int id)
        {
            return File(_postService.GetById(id).Image, "image/jpeg");
        }

        public ActionResult PostDetails(int id)
        {
            var photo = _postService.GetById(id).ToPostDetailsViewModel();
            photo.Owner = _accountService.GetUserById(photo.UserId).ToPostOwnerViewModel();
            if (Request.IsAuthenticated)
            {
                photo.CurrentUserId = _accountService.GetUserByLogin(User.Identity.Name).Id;
            }

            var pageInfo = new PageInfo
            {
                PageNumber = 1,
                PageSize = CommentOnPage,
                TotalItems = _postService.CountCommentByPostId(id)
            };

            var comments = _postService.GetCommentsByPostId(id, 0, CommentOnPage)
                .Select(p => p.ToCommentViewModel()).ToList();

            foreach (var comment in comments)
            {
                comment.Author.Name = _postService.GetAuthorById(comment.Author.Id).Login;
            }

            ViewBag.Comments = new PaginationViewModel<CommentViewModel> { PageInfo = pageInfo, Items = comments };

            photo.UserLikesLogins = new List<string>();

            foreach (var userId in photo.UserLikesIds)
            {
                photo.UserLikesLogins.Add(_postService.GetAuthorById(userId).Login);
            }

            return PartialView("_PostDetails", photo);
        }

        [Authorize]
        public ActionResult LikePost(int postId)
        {
            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;
            _postService.LikePost(userId, postId);
            PostRatingViewModel photo = _postService.GetById(postId).ToPostRatingViewModel();
            return PartialView("_LikePhoto", photo);
        }

        [Authorize]
        public ActionResult DislikePost(int postId)
        {
            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;
            _postService.DislikePost(userId, postId);
            PostRatingViewModel photo = _postService.GetById(postId).ToPostRatingViewModel();
            return PartialView("_DislikePhoto", photo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;
            _postService.AddComment(model.ToBllComment(userId, User.Identity.Name));
            return RedirectToAction("LoadMoreComment", new { page = 0, id = model.PostId });
        }

        public ActionResult LoadMoreComment(int page, int id)
        {
            var pageInfo = new PageInfo
            {
                PageNumber = page + 1,
                PageSize = CommentOnPage,
                TotalItems = _postService.CountCommentByPostId(id)
            };

            IEnumerable<CommentViewModel> comments = _postService.GetCommentsByPostId(id,
                pageInfo.Skip, pageInfo.PageSize).Select(p => p.ToCommentViewModel()).ToList();

            foreach (var comment in comments)
            {
                comment.Author.Name = _postService.GetAuthorById(comment.Author.Id).Login;
            }

            var model = new PaginationViewModel<CommentViewModel> { PageInfo = pageInfo, Items = comments };
            return PartialView("_Comments", model);
        }

        [Authorize]
        public ActionResult DeletePost(int postId)
        {
            _postService.Delete(postId);
            return RedirectToAction("Index");
        }
    }
}