using MvcPL.Helper;
using MvcPL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class PayController : Controller
    {
        public ActionResult MakeAd()
        {
            return View("MakeAd");
        }

        [HttpPost]
        public ActionResult MakeAd(UploadAdViewModel post)
        {
            //TODO GET FROM DB
            FeelViewBagWithAd();
            PayModel.Model = post;
            return View("MakeAdFeatures", post);
        }

        [HttpGet]
        public ActionResult PayPage()
        {            
            return View("PayPage", model: PayModel.Model.Price);
        }

        [HttpPost]
        public ActionResult DoPay(string m)
        {
            //TODO Save to DB
            return View("PayPage");
            //return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public void PostPrice(string price)
        {
            PayModel.Model.Price = price;
        }

        private void FeelViewBagWithAd()
        {
            var list = new SelectList(AdHelper.CountryList(), "Key", "Value");
            var sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = new SelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.SexList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Sex = new SelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.AgeList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.AgeBegin = new SelectList(sortList, "Value", "Text");
            
            list = new SelectList(AdHelper.LanguagesList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Languages = new SelectList(sortList, "Value", "Text");
        }
    }
}