using AlfaPay.Domain.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaPay.Domain.Test
{
    public class Program
    {
		public static void Main(string[] args)
		{
			Processing.Payment.Card card = new Processing.Payment.Card() { BIN = "415481" };
			var v = Processing.Services.PayService.GetInfoByBIN(card);

			Console.WriteLine(v.BankName);

			Processing.Payment.Transaction transaction = new Processing.Payment.Transaction();
			Processing.Payment.PayCard cardPay = new Processing.Payment.PayCard()
			{
				ExpirationDate = "201803",
				CardNumber = "5213243739046055"
			};
			Processing.Payment.PayCard cardPay2 = new Processing.Payment.PayCard()
			{
				ExpirationDate = "201803",
				CardNumber = "5486732189862220"
			};
			transaction.Sender = new Processing.Payment.CardHolder()
			{
				Card = cardPay
			};
			transaction.Recipient = new Processing.Payment.CardHolder()
			{
				Card = cardPay2
			};

			transaction.Amount = 210;
			transaction.Currency = "RUR";
			transaction.ClientIP = "127.0.0.1";
			var v1 = Processing.Services.PayService.InitPayment(transaction);

			Console.WriteLine(v1.TemplateId);
		}
    }
}
