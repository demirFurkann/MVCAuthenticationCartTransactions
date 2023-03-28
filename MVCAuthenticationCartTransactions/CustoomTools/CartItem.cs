﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.CustoomTools
{
	public class CartItem
	{

		public int ID { get; set; }

		public string ProductName { get; set; }

		public decimal? UnitPrice { get; set; }

		public short Amount { get; set; }

		public decimal? SubTotal { get { return Amount * UnitPrice; } }


		public CartItem()
		{
			Amount++;
		}
	}
}