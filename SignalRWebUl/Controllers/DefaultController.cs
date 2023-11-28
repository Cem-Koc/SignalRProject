using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUl.Dtos.MessageDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUl.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonDate = JsonConvert.SerializeObject(createMessageDto);
			StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7114/api/Messages", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
