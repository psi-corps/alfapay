using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace AlfaPay.Web.Frontoffice.Api.Controllers
{
	[Route("api")]
    public class HomeController : ControllerBase
    {
		[HttpGet("hello")]
		public async Task<string> SayHello(string name)
		{
			return await Task.FromResult($"Hello, {name}!");
		}
	}
}
