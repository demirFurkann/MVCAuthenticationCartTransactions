using MVCAuthenticationCartTransactions.AuthenticationClasses;
using MVCAuthenticationCartTransactions.CustoomTools;
using MVCAuthenticationCartTransactions.DesignPattern.SingletonPattern;
using MVCAuthenticationCartTransactions.Models.Context;
using MVCAuthenticationCartTransactions.Models.Entities;
using MVCAuthenticationCartTransactions.Models.PageVMs;
using MVCAuthenticationCartTransactions.Models.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationCartTransactions.Controllers
{

	public class ShoppingController : Controller
    {
        MyContext _db;
        public ShoppingController()
        {
            _db = DBTool.DbInstance;
        }
		[AdminAuthentication]
		public ActionResult ProductList()
        {
            List<ProductVM> products = _db.Product.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,

            }).ToList();

            ProductListPageVM pvm = new ProductListPageVM
            {
                Products = products,
            };

            return View(pvm);
        }

        private CartItem SepeteYolla(int id )
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product eklenecekUrun = _db.Product.Find(id);

            CartItem ci = new CartItem();
            ci.ID = eklenecekUrun.ID;
            ci.ProductName = eklenecekUrun.ProductName;
            ci.UnitPrice = eklenecekUrun.UnitPrice;
            c.SepeteEkle(ci);

            Session["scart"] = c;
            return ci;
        }

        public ActionResult AddToCart(int id)
        {
            CartItem ci = SepeteYolla(id);

            TempData["mesaj"] = $"{ci.ProductName} İsimli ürün sepete eklenmiştir";

            return RedirectToAction("ProductList");
        }

        public ActionResult CartPage()
        {
            if (Session["scart"]!= null)
            {
                Cart c = Session["scart"] as Cart;
                CartPageVM cpvm = new CartPageVM
                {
                    Cart = c,
                };
				return View(cpvm);

			}
            ViewBag.SepetBos = "Sepetenizdek Ürün Bulunmamaktadır";
            return View();
        }
        public ActionResult DeleteFromCart(int id)
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;

                c.SepettenSil(id);
                if (c.Sepetim.Count == 0) Session.Remove("scart");
                return RedirectToAction("CartPage");
            }
            return RedirectToAction("ProductList");
        }

        public ActionResult IncreaseAmount(int id)
        {
            SepeteYolla(id);
            return RedirectToAction("CartPage");
        }

        public ActionResult DestroyFromCart(int id)
        {
            if (Session["scart"]!= null)
            {
                Cart c = Session["scart"] as Cart;
                c.Yoket(id);
                return RedirectToAction("CartPage");
            }
            return View();
        }
    }
}