using Microsoft.AspNetCore.Mvc;

namespace ShoesStore.ViewComponents
{
    public class VoucherViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
