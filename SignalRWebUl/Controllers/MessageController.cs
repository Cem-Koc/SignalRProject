using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUl.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
