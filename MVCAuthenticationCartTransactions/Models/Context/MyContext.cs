using MVCAuthenticationCartTransactions.Models.Entities;
using MVCAuthenticationCartTransactions.Models.Init;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Context
{
	public class MyContext:DbContext
	{
		public MyContext():base("MyConnection")
		{
			Database.SetInitializer(new MyInit());
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUser>().HasOptional(x => x.AppUserProfile).WithRequired(x => x.AppUser);
			modelBuilder.Entity<OrderDetail>().Ignore(x => x.ID);
			modelBuilder.Entity<OrderDetail>().HasKey(x => new
			{
				x.OrderID,
				x.ProductID
			});

		}

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<AppUserProfile> AppUserProfiles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders{ get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Product> Product { get; set; }
	}
}