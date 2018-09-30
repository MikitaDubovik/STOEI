using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Helper;
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

        public ActionResult MakeAd()
        {
            return View("MakeAd");
        }

        [HttpPost]
        public ActionResult MakeAd(UploadAdViewModel post)
        {
            FeelViewBagWithAd();

            return View("MakeAdFeatures", post);
        }

        public ActionResult Calculate(UploadAdViewModel post)
        {
            post.Countries = Request.Form["DdlCountries"];
            post.Sex = Request.Form["DdlSex"];
            post.Age = Request.Form["DdlAgeBegin"] + " " + Request.Form["DdlAgeEnd"];
            post.Language = Request.Form["DdlLanguage"];

            var price = PriceCounter.Calculate(post);
            return PartialView(price);
        }

        [HttpPost]
        public ActionResult MakeAdFeatures(UploadAdViewModel post)
        {
            post.Countries = Request.Form["DdlCountries"];
            post.Sex = Request.Form["DdlSex"];
            post.Age = Request.Form["DdlAgeBegin"] + " " + Request.Form["DdlAgeEnd"];
            post.Language = Request.Form["DdlLanguage"];

            var price = PriceCounter.Calculate(post);

            return RedirectToAction("Index", "Profile");
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

        private void FeelViewBagWithAd()
        {
            var list = new SelectList(AdHelper.CountryList(), "Key", "Value");
            List<SelectListItem> sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = new MultiSelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.SexList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Sex = new MultiSelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.AgeListBegin(), "Value", "Key");
            sortList = list.OrderBy(p => int.Parse(p.Text)).ToList();
            sortList.Add(new SelectListItem{Text = "", Value = ""});
            ViewBag.AgeBegin = new MultiSelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.AgeListEnd(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            sortList.Add(new SelectListItem { Text = "", Value = "" });
            ViewBag.AgeEnd = new MultiSelectList(sortList, "Value", "Text");


            list = new SelectList(AdHelper.LanguagesList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Languages = new MultiSelectList(sortList, "Value", "Text");
        }
    }
}