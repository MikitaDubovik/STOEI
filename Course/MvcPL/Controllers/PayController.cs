﻿using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Helper;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

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
            var list = new SelectList(_payService.GetCountries(), "CountryId", "Label");
            var sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = new SelectList(sortList, "Value", "Text");

            list = new SelectList(_payService.GetSex(), "SexId", "Label");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Sex = new SelectList(sortList, "Value", "Text");

            list = new SelectList(_payService.GetAges(), "AgeId", "Label");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.AgeBegin = new SelectList(sortList, "Value", "Text");

            list = new SelectList(_payService.GetLanguages(), "LanguageId", "Label");
            sortList = list.OrderBy(p => p.Text).ToList();
            ViewBag.Languages = new SelectList(sortList, "Value", "Text");
        }
    }
}