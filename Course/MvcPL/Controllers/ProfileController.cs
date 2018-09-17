using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure;
using MvcPL.Models;
using MvcPL.Models.Pagination;

namespace MvcPL.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public const int ImagesOnPage = 10;
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;

        public ProfileController(IAccountService accountService, IPostService postService)
        {
            _accountService = accountService;
            _postService = postService;
        }

        public ActionResult Index()
        {
            ProfileViewModel profileViewModel = _accountService.
                GetUserByLogin(User.Identity.Name).ToProfileViewModel();

            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;

            PageInfo pageInfo = new PageInfo
            {
                PageNumber = 1,
                PageSize = ImagesOnPage,
                TotalItems = _postService.CountByUserId(userId)
            };
            IEnumerable<PostViewModel> photos = _postService.GetByUserId(userId, 0, ImagesOnPage)
                .Select(p => p.ToPostViewModel());
            ViewBag.Posts = new PaginationViewModel<PostViewModel> { PageInfo = pageInfo, Items = photos };

            return View("Index", profileViewModel);
        }

        public ActionResult LoadMorePosts(int page)
        {
            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;

            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page + 1,
                PageSize = ImagesOnPage,
                TotalItems = _postService.CountByUserId(userId)
            };
            IEnumerable<PostViewModel> photos = _postService.GetByUserId(userId,
                pageInfo.Skip, pageInfo.PageSize).Select(p => p.ToPostViewModel());

            var model = new PaginationViewModel<PostViewModel> { PageInfo = pageInfo, Items = photos };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowImage()
        {
            return File(_accountService.GetUserByLogin(User.Identity.Name).ProfilePhoto, "image/jpeg");
        }

        [AllowAnonymous]
        public ActionResult ShowProfilePost(int userId)
        {
            return File(_accountService.GetUserById(userId).ProfilePhoto, "image/jpeg");
        }

        public ActionResult UploadPost()
        {
            return View("UploadPost");
        }

        [HttpPost]
        public ActionResult UploadPost(UploadPostViewModel photo)
        {
            _postService.Add(photo.ToBllPost(_accountService.GetUserByLogin(User.Identity.Name).Id));
            return RedirectToAction("Index", "Profile");
        }

        public ActionResult EditProfile()
        {
            ProfileInfoViewModel profileViewModel = _accountService.
                GetUserByLogin(User.Identity.Name).ToProfileInfoViewModel();
            return View("EditProfile", profileViewModel);
        }

        [HttpPost]
        public ActionResult EditPtofile(EditProfileViewModel model)
        {
            int userId = _accountService.GetUserByLogin(User.Identity.Name).Id;
            _accountService.EditeUserPtofile(userId, model.Name, model.ImageFile.ToByteArray());
            return RedirectToAction("Index", "Profile");
        }

    }
}