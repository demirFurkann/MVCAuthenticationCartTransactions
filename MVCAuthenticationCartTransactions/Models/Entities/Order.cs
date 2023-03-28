using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Entities
{
	public class Order : BaseEntitiy
	{

		public string ShippingAddress { get; set; }

		public int? AppUserID { get; set; }



		//Relational Properties

		public virtual  AppUser AppUser { get; set; }

		public virtual List<OrderDetail> OrderDetails { get; set; }

	}
}