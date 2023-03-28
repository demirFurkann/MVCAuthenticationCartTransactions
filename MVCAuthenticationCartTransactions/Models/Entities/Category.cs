﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Entities
{
	public class Category:BaseEntitiy
	{
		public string CategoryName { get; set; }

		public string Description { get; set; }

		//Relational Properties

		public virtual List<Product> Products { get; set; }
	}
}