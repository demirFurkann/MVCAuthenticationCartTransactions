using MVCAuthenticationCartTransactions.Models.Context;
using MVCAuthenticationCartTransactions.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Init
{
	public class MyInit : CreateDatabaseIfNotExists<MyContext>
	{
		protected override void Seed(MyContext context)
		{
			AppUser ap = new AppUser
			{
				UserName = "furkan",
				Password = "123",
				Role = Enums.UserRole.Admin
			};

			AppUser ap2 = new AppUser
			{
				UserName = "admin",
				Password = "123",
				Role = Enums.UserRole.Admin

			};
			context.AppUsers.Add(ap);	
			context.AppUsers.Add(ap2);	
			context.SaveChanges();
		}
	}
}