using Microsoft.AspNetCore.Mvc;

namespace ShoesStore.Controllers
{
    public class TrackingOrderController : Controller
    {
        public IActionResult Tracking()
        {
            return View();
        }
    }
}
