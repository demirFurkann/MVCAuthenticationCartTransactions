using MVCAuthenticationCartTransactions.DesignPattern.SingletonPattern;
using MVCAuthenticationCartTransactions.Models.Context;
using MVCAuthenticationCartTransactions.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationCartTransactions.Controllers
{
    public class HomeController : Controller
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DbInstance;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(AppUser appUser)
        {
            if(_db.AppUsers.Any(x => x.UserName ==appUser.UserName && x.Password == appUser.Password&&x.Role == Models.Enums.UserRole.Admin))
            {
                Session["admin"] = _db.AppUsers.FirstOrDefault(x => x.UserName == appUser.UserName && x.Password == appUser.Password);
                return RedirectToAction("ProductList","Shopping");
            }
            ViewBag.Message = "Kullanıcı ya yetkisi yok yada böyle bir kullanıcı yok";
            return View();
        }
    }
}