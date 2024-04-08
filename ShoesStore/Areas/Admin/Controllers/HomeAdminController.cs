using Microsoft.AspNetCore.Mvc;
using ShoesStore.Models.Authentication;


namespace ShoesStore.Areas.Admin.Controllers
{
    [Area("Admin") ]
    [AuthenticationM_S]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
