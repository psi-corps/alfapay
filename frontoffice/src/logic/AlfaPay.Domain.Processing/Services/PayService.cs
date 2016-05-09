using AlfaPay.Domain.Processing.Payment;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace AlfaPay.Domain.Processing.Services
{
	public static class PayService
	{
		public const string Server = "https://testjmb.alfabank.ru";
		public const string UserToken = "6bb506c4-1332-439d-9e7d-c7853e867345";
		public const string UserAuthString = "Bearer " + UserToken;
		public const string PartnerAuthString = "Basic " + "VEVTVDp0ZXN0X3VzZXJfc2VjcmV0";
		public const string GetUserTokenURL = "/uapidemo/api/oauth/token";
		public const string CalcCommURL = "/uapidemo/uapi/v1/fee";
		public const string InitTransURL = "/uapidemo/api/v1/transfers";
		public const string FinishTransURL = "";
		public const string CheckBinURL = "/api/v1/banks/byCardNumber/";
		public const string GetTransInfoURL = "";

		public static Card GetInfoByBIN(Card card)
		{
			string url = String.Format("{0}{1}{2}", Server, CheckBinURL, card.BIN);
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", PartnerAuthString);
				var response = client.GetAsync(url).Result;

				if (response.IsSuccessStatusCode)
				{
					var responseContent = response.Content;

					string responseString = responseContent.ReadAsStringAsync().Result;
					card = JsonConvert.DeserializeObject<Card>(responseString);
				}
			}

			return card;
		}

		public static FullTransaction InitPayment(Transaction trans)
		{
			string url = String.Format("{0}{1}", Server, InitTransURL);
			FullTransaction answer = new FullTransaction();
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", UserAuthString);

				HttpContent content = new StringContent(
				   JsonConvert.SerializeObject(trans), Encoding.UTF8, "application/json");

				var response = client.PutAsync(url, content)
					 .Result;
				
				if (response.IsSuccessStatusCode)
				{
				 
					var responseContent = response.Content;

					string responseString = responseContent.ReadAsStringAsync().Result;
					answer = JsonConvert.DeserializeObject<FullTransaction>(responseString);
				}
			}


			return answer;


		}

	}
}
