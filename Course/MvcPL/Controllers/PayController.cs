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
            List<SelectListItem> sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = new MultiSelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.SexList(), "Value", "Key");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Sex = new MultiSelectList(sortList, "Value", "Text");

            list = new SelectList(AdHelper.AgeListBegin(), "Value", "Key");
            sortList = list.OrderBy(p => int.Parse(p.Text)).ToList();
            sortList.Add(new SelectListItem { Text = "", Value = "" });
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