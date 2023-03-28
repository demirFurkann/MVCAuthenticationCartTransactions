using MVCAuthenticationCartTransactions.AuthenticationClasses;
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
	[AdminAuthentication]
	public class CategoryController : Controller
	{
		MyContext _db;
		public CategoryController()
		{
			_db = DBTool.DbInstance;
		}
		public ActionResult ListCategories()
		{
			List<CategoryVM> categories = _db.Categories.Select(x => new CategoryVM
			{
				ID = x.ID,
				CategoryName = x.CategoryName,
				Description = x.Description,
			}).ToList();
			ListCategoryPageVM lcvm = new ListCategoryPageVM
			{
				Categories = categories,
			};
			return View(lcvm);
		}
		public ActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCategory(CategoryVM category)
		{
			Category c = new Category
			{
				CategoryName = category.CategoryName,
				Description = category.Description,

			};
			_db.Categories.Add(c);
			_db.SaveChanges();
			return RedirectToAction("ListCategories");

		}
		public ActionResult UpdateCategory(int id )
		{
			CategoryVM category = _db.Categories.Select(x => new CategoryVM
			{
				ID = x.ID,
				CategoryName = x.CategoryName,
				Description = x.Description,
			}).FirstOrDefault(x => x.ID == id);
			AddUpdateCategoryPageVM aupvm = new AddUpdateCategoryPageVM
			{
				Category = category,
			};
			return View(aupvm);

		}
		[HttpPost]

		public ActionResult UpdateCategory(Category category)
		{
			Category toBeUpdated = _db.Categories.Find(category.ID);
			toBeUpdated.Description = category.Description;
			toBeUpdated.CategoryName = category.CategoryName;
			_db.SaveChanges();

			return RedirectToAction("ListCategories");
		}

		public ActionResult DeleteCategory(int id)
		{
			_db.Categories.Remove(_db.Categories.Find(id));
			_db.SaveChanges();

			return RedirectToAction("ListCategories");
		}

	}
}