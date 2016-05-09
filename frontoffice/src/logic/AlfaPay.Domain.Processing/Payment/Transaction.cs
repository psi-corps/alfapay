using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaPay.Domain.Processing.Payment
{
	public class Transaction
	{	
		[JsonProperty("currency")]
		public string Currency { get; set; }
		[JsonProperty("amount")]
		public decimal? Amount { get; set; }
		[JsonProperty("client_ip")]
		public string ClientIP { get; set; }
		[JsonProperty("sender")]
		public CardHolder Sender { get; set; }
		[JsonProperty("recipient")]
		public CardHolder Recipient { get; set; }
	}
	public class FullTransaction : Transaction
	{
		[JsonProperty("transaction_id")]
		public int Id { get; set; }
		[JsonProperty("termURL")]
		public string TermURL { get; set; }
		[JsonProperty("status")]
		public string Status { get; set; }
		[JsonProperty("md")]
		public string MD { get; set; }
		[JsonProperty("acsURL")]
		public string AcsURL { get; set; }
		[JsonProperty("pareq")]
		public string PaReq { get; set; }
		[JsonProperty("template_id")]
		public string TemplateId { get; set; }

		/*
		 {
	"sender": {
		"card": {
			"number": "5213243739046055",
			"exp_date": "201803"
		}
	},
	"recipient": {
		"card": {
			"number": "5486732189862220",
 "exp_date": "201803"
		}
	},
	"amount": "10",
	"currency": "RUR",
	"client_ip": "127.0.0.1"
}


		{
  "recipient": {
    "card": {
      "id": "376195902"
    }
  },
  "sender": {
    "card": {
      "id": "31439947"
    }
  },
  "termURL": "https://testjmb.alfabank.ru/uapi10/transfers",
  "status": "WAITING",
  "md": "ddac2c0dfb8248db992da5aadd3b9618",
  "acsURL": "https://testjmb.alfabank.ru/uapidemo/uapi/v1/check3ds.html?md=ddac2c0dfb8248db992da5aadd3b9618",
  "pareq": "eJxVUU1TgzAU/CsMd0kCIXQ6j3Sw6NgDTq3twWOE2KIltAG0/nsTPqwektl9edls9sHiUh2dT6mb\\nslaxSzzsOlLldVGqfezutvc3M3fBYXvQUqbPMu+05JDJphF76ZRF7FbN3iMuh3WykWcOoxI3Qp4P\\naKLmis4PQrUcRH6+XT3ykM5YFAAaKVRSr1JOfBIEfr8HGOMeUEDDIShRSb5MNqlvN0A9h7zuVKu/\\nOaNGbiLQ6SM/tO1pjpA4volXoT483QGydUBXO+vOosboXMqCZ2nyNaw7nL2/kGybkSx9CrN0FwOy\\nHVCIVnIfkxAHhDmEzWk4x8ZjXwdRWQOcYPOzAcLJvpBc6385mEC1yXtyPzGQl1OtpOkwIf5iQFe3\\nywcbZd6aXG5MTIyxICLEiyJCKWUMh5gEfkRtwH2TVSxNMCTCg6QlgKwMGmeHxrka9G/eP9n9rmQ=",
  "transaction_id": "608853381",
  "template_id": "502662154"
}
		 */
	}
}
