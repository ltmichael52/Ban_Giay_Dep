using System;
using System.Collections.Generic;
using System.Linq;
using ShoesStore.Areas.Admin.InterfaceRepositories;
using ShoesStore.Areas.Admin.ViewModels;
using ShoesStore.Models;

namespace ShoesStore.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ShoesDbContext _context;

        public ReportRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public List<ReportViewModel> GetSaleReportForMonthYear(int month)
        {
            var saleReports = _context.Phieumuas
             .Where(pm => pm.Ngaydat.Month == month && pm.Ngaydat.Year == DateTime.Now.Year)
             .SelectMany(pm => pm.Chitietphieumuas)
             .Select(ct => new {
                 Tendongsp = ct.MaspsizeNavigation.MaspNavigation.MadongsanphamNavigation.Tendongsp, // Assuming Tendongsp is the property representing the product name
                 ct.Dongia,
                 ct.Soluong
             })
             .ToList();


            var aggregatedSaleReports = saleReports
                .GroupBy(sr => sr.Tendongsp)
                .Select(group => new ReportViewModel
                {
                    Tendongsp = group.Key,
                    doanhThu = group.Sum(item => item.Dongia * item.Soluong)
                })
                .ToList();

            var totalRevenue = aggregatedSaleReports.Sum(sr => sr.doanhThu);

            // Calculate percentages
            // Calculate percentages
            foreach (var saleReport in aggregatedSaleReports)
            {
                saleReport.tyle = totalRevenue != 0 ? (decimal)saleReport.doanhThu / totalRevenue : 0;
            }



            return aggregatedSaleReports;
        }
    }
}
