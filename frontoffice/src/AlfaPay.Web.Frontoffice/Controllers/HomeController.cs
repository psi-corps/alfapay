using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace AlfaPay.Web.Frontoffice.Api.Controllers
{
	[Route("api")]
    public class HomeController  
    {
		[HttpGet("hello")]
		public async Task<string> SayHello(string name)
		{
			return await Task.FromResult($"Hello, {name}!");
		}
	}
}


/*
  - Membership: reg/auth;
  - Transfer: init+3DSecure/comission/state;
  - Card: info/add/get/update/delete/id
  - Template: get/delete/update
  - History: all/one
*/

/*
	npm 
*/