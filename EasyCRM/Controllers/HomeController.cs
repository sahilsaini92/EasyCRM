using EasyCRM.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Address([Bind(Prefix = "Address")] AddressCreateViewModel viewModel)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Address");
            return PartialView("~/Views/Shared/EditorTemplates/_address.cshtml", viewModel);
        }
    }
}