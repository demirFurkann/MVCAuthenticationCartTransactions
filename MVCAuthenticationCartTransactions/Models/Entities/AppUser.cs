using MVCAuthenticationCartTransactions.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Entities
{
	public class AppUser:BaseEntitiy
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		

		public AppUser()
		{
			Role = UserRole.Member;
		}

		//Relational Properties

		public virtual AppUserProfile AppUserProfile { get; set; }

		public virtual List<Order> Orders { get; set; }

	}
}