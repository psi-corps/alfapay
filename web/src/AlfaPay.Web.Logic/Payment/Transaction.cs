using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaPay.Web.Frontoffice.Models.Payment
{
	 public class Transaction  
	{
	 
		public string Currency { get; set; }
		public double? Amount { get; set; }
		public string ClientIP { get; set; }
		public CardHolder Sender { get; set; }

		public CardHolder Recipient { get; set; }

	}
}
