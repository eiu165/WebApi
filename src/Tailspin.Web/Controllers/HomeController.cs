using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tailspin.Business;

namespace Tailspin.Web.Controllers
{
    public class HomeController : Controller
    {
        private IToyService _toyService;
        public HomeController (IToyService toyService)
        {
            this._toyService = toyService;
        }
        public ActionResult Index()
        {
            var toys = _toyService.Get();
            return View(toys);
        }

    }
}
