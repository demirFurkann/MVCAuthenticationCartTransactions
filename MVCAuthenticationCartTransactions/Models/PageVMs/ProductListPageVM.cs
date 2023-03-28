using MVCAuthenticationCartTransactions.Models.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.PageVMs
{
	public class ProductListPageVM
	{

		public List<ProductVM> Products { get; set; }
	}
}