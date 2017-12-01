using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountVM model, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(model.username, model.password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(model.username, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            }
            else
            {
                ModelState.AddModelError("", "");
                return View(model);
            }
            //bool result = FormsAuthentication.Authenticate(username, password);
            //if (result)
            //{
            //    FormsAuthentication.SetAuthCookie(username, false);
            //    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Incorrect username or password");
            //    return View();
            //}
        }
	}
}