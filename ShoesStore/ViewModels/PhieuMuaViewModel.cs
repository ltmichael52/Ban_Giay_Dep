using ShoesStore.Models;

namespace ShoesStore.ViewModels
{
    public class PhieuMuaViewModel
    {
        public List<ShoppingCartItem> listcartItem {  get; set; }
        public Khachhang khInfo {  get; set; }
        public string? GhiChu {  get; set; }
        public int Mapttt {  get; set; }

         public string HoTen {  get; set; }
        public string Sdt {  get; set; }
        public List<Sodiachi> sodiachis {  get; set; }
    }
}
