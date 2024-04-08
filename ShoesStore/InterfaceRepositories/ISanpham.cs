using ShoesStore.Models;
using ShoesStore.ViewModels;

namespace ShoesStore.InterfaceRepositories
{
    public interface ISanpham
    {
        Sanpham Getsanpham(int masp);
        SanphamViewModel HienThiSanpham(int madongsanpham, int masp);
    }
}
