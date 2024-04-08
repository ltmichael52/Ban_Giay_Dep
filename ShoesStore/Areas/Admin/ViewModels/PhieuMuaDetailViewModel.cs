using ShoesStore.Models;

namespace ShoesStore.Areas.Admin.ViewModels
{
    public class PhieuMuaDetailViewModel
    {
        public int Mapm { get; set; }
        public string Tendongsp { get; set; } = null!;
        public IEnumerable<Chitietphieumua> Chitietphieumuas { get; set; }
    }
}
