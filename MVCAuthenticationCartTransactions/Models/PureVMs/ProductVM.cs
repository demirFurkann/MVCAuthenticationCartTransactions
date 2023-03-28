using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.PureVMs
{
	public class ProductVM
	{
		public int ID { get; set; }

		public string ProductName { get; set; }

		public decimal? UnitPrice { get; set; }

		public int? CategoryID { get; set; }

		public string CategoryName { get; set; }

	}
}