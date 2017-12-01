using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuth(false)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }
	}
}