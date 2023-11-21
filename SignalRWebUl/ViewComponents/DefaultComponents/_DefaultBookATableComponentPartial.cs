using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUl.ViewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
