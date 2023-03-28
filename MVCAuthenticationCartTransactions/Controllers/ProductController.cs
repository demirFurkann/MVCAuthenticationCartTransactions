using MVCAuthenticationCartTransactions.AuthenticationClasses;
using MVCAuthenticationCartTransactions.DesignPattern.SingletonPattern;
using MVCAuthenticationCartTransactions.Models.Context;
using MVCAuthenticationCartTransactions.Models.Entities;
using MVCAuthenticationCartTransactions.Models.PageVMs;
using MVCAuthenticationCartTransactions.Models.PureVMs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationCartTransactions.Controllers
{
	[AdminAuthentication]
	public class ProductController : Controller
    {
        MyContext _db;
        public ProductController()
        {
            _db = DBTool.DbInstance;
        }

        public ActionResult ListProducts()
        {
            List<ProductVM> products = _db.Product.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName=x.Category.CategoryName,
            }).ToList();

            ProductListPageVM pvm = new ProductListPageVM
            {
                Products = products
            };
            return View(pvm);

        }
        public List<CategoryVM> GetCategories()
        {
            return _db.Categories.Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description,


            }).ToList();
        }
        public ActionResult AddProduct()
        {
            List<CategoryVM> categories = GetCategories();
            AddUpdateProductPageVM auPvm = new AddUpdateProductPageVM
            {
                Categories = categories,
            };
            return View(auPvm);
        }
        [HttpPost]
        
        public ActionResult AddProduct(ProductVM product)
        {
            Product p = new Product()
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryID = product.CategoryID,
            };
            _db.Product.Add(p);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");

        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = _db.Product.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category.CategoryName
            }).FirstOrDefault(x => x.ID == id);
            List<CategoryVM> categories = GetCategories();
            AddUpdateProductPageVM aupvm = new AddUpdateProductPageVM
            {
                Categories = categories,
                Product = pvm
            };
            return View(aupvm);
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductVM product)
        {
            Product pro = _db.Product.Find(product.ID);
                pro.ProductName = product.ProductName;
            pro.UnitPrice = product.UnitPrice;
            pro.CategoryID = product.CategoryID;
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Product.Remove(_db.Product.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

    }
}