using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUl.ViewComponents.UILayoutComponents
{
	public class _UILayoutHeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
