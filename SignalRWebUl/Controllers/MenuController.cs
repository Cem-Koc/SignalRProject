using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUl.Dtos.BasketDtos;
using SignalRWebUl.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUl.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7114/api/Product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

		[HttpPost]
		public async Task<IActionResult> AddBasket(int id)
		{
            CreateBasketDto createBasketDto = new CreateBasketDto();
			createBasketDto.ProductID = id;
			var client = _httpClientFactory.CreateClient();
			var jsonDate = JsonConvert.SerializeObject(createBasketDto);
			StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7114/api/Baskets", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return Json(createBasketDto);
		}
	}
}
