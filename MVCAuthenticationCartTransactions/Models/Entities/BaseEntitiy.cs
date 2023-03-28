using MVCAuthenticationCartTransactions.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthenticationCartTransactions.Models.Entities
{
	public class BaseEntitiy
	{
		public int ID { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime? ModifedDate { get; set; }

		public DateTime? DeletedDate { get; set; }

		public DataStatus Status { get; set; }

		public UserRole Role { get; set; }

		public BaseEntitiy()
		{
			CreatedDate = DateTime.Now;
			Status = DataStatus.Inserted;
			
			
		}
	}
}