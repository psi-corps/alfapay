using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfaPay.Domain.Processing.Payment
{
    public class CardHolder
    {
		[JsonProperty("card")]
		public PayCard Card { get; set; }
    }
}
