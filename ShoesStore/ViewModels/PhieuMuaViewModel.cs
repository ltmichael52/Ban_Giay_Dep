using ShoesStore.Models;

namespace ShoesStore.ViewModels
{
    public class PhieuMuaViewModel
    {
        public List<ShoppingCartItem> listcartItem {  get; set; }
        public Khachhang khInfo {  get; set; }
        public string? GhiChu {  get; set; }
        public int Mapttt {  get; set; }

    }
}
