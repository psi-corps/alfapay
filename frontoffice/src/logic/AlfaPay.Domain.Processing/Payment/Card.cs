using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlfaPay.Domain.Processing.Payment
{
    public class Card
    {

		[JsonProperty("number")]
		public string CardNumber { get; set; }
		[JsonProperty("identificator")]
		public string CardId { get; set; }
		[JsonProperty("exp_date")]
		public string ExpirationDate { get; set; }
		[JsonProperty("color")]
		public string Color { get; set; }
		[JsonProperty("country")]
		public string Country { get; set; }
		[JsonProperty("name")]
		public string BankName { get; set; }
		[JsonProperty("operations")]
		public string Operations { get; set; }
		[JsonProperty("paymentSystem")]
		public string PaymentSystem { get; set; }
		public string BIN { get; set; }
		public bool? Active { get; set; }


	}

	public class PayCard
	{

		[JsonProperty("number")]
		public string CardNumber { get; set; }
	
		[JsonProperty("exp_date")]
		public string ExpirationDate { get; set; }
	 
		 


	}
}
