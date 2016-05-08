using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlfaPay.Web.Frontoffice.Models.Payment
{
    public class Card
    {
		public string CardNumber { get; set; }
		public string CardId { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Color { get; set; }
		public string Country { get; set; }
		public string BankName { get; set; }
		public string Operations { get; set; }
		public string PaymentSystem { get; set; }
		public string BIN { get; set; }
		public bool? Active { get; set; }


	}
}
