using System.Collections.Generic;
using ShoesStore.Areas.Admin.ViewModels;

namespace ShoesStore.Areas.Admin.InterfaceRepositories
{
    public interface IReportRepository
    {
        List<ReportViewModel> GetSaleReportForMonthYear(int month);
    }
}
