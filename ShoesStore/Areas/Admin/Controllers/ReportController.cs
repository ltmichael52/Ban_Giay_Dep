using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoesStore.Areas.Admin.InterfaceRepositories;
using ShoesStore.Areas.Admin.ViewModels;

namespace ShoesStore.Controllers
{
    [Area("Admin")]

    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IActionResult Index(string sortOrder, int manager)
        {
            TempData["Manager"] = manager;
            ViewBag.Month = DateTime.Now.Month;

            List<ReportViewModel> salerp = _reportRepository.GetSaleReportForMonthYear(ViewBag.Month);

            // Sorting logic for 'Tỷ lệ'
            ViewData["TyleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "tyle_desc" : "";

            switch (sortOrder)
            {
                case "tyle_desc":
                    salerp = salerp.OrderByDescending(s => s.tyle).ToList();
                    break;
                default:
                    salerp = salerp.OrderBy(s => s.tyle).ToList();
                    break;
            }

            return View(salerp);
        }

        [HttpPost]
        public IActionResult Index(int month, string sortOrder, int manager)
        {
            TempData["Manager"] = manager;
            ViewBag.Month = month;

            List<ReportViewModel> salerp = _reportRepository.GetSaleReportForMonthYear(ViewBag.Month);

            // Sorting logic for 'Tỷ lệ'
            ViewData["TyleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "tyle_desc" : "";

            switch (sortOrder)
            {
                case "tyle_desc":
                    salerp = salerp.OrderByDescending(s => s.tyle).ToList();
                    break;
                default:
                    salerp = salerp.OrderBy(s => s.tyle).ToList();
                    break;
            }

            return View(salerp);
        }
    }
}
