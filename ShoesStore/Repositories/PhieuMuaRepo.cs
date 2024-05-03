using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.ViewModels;

namespace ShoesStore.Repositories
{
    public class PhieuMuaRepo : IPhieuMua
    {
        ShoesDbContext context;
        public PhieuMuaRepo(ShoesDbContext context)
        {
            this.context = context;
        }

        public void AddPhieuMua(PhieuMuaViewModel phieuMua)
        {
            decimal tongtien = 0;
            foreach (ShoppingCartItem cartItem in phieuMua.listcartItem)
            {
                if(cartItem.PhanTramGiam > 1)
                {
                    tongtien += cartItem.Quantity * (cartItem.GiaGoc - cartItem.GiaGoc * cartItem.PhanTramGiam / 100);
                }
                else
                {
                    tongtien += cartItem.Quantity * cartItem.GiaGoc;
                }
            }

            Phieumua newpm = new Phieumua()
            {
                Ghichu = phieuMua.GhiChu,
                Makh = phieuMua.khInfo.Makh,
                Ngaydat = DateTime.Now,
                Tinhtrang = "Chưa duyệt",
                Mapttt = phieuMua.Mapttt,
                MaptttNavigation = context.Phuongthucthanhtoans.Find(phieuMua.Mapttt),
                Tongtien = tongtien
            };
            
            context.Phieumuas.Add(newpm);
            context.SaveChanges();

            List<Chitietphieumua> ctpmList = new List<Chitietphieumua>();
            foreach (ShoppingCartItem cartItem in phieuMua.listcartItem)
            {
                ctpmList.Add(new Chitietphieumua()
                {
                    Mapm = newpm.Mapm,
                    Maspsize = cartItem.Maspsize,
                    Soluong = cartItem.Quantity,
                    Dongia = cartItem.PhanTramGiam > 1 ? (cartItem.GiaGoc - cartItem.GiaGoc * cartItem.PhanTramGiam / 100) : cartItem.GiaGoc,
                });
            }

            context.Chitietphieumuas.AddRange(ctpmList);
            context.SaveChanges();

        }
    }
}
