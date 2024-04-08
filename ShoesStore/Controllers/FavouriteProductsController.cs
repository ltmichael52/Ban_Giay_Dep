using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.Models.Session;
using ShoesStore.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShoesStore.Controllers
{
	public class FavouriteProductsController : Controller
	{
		ISanpham sanphamrepo;
		IDongSanpham _product;
		ISize _size;
		ISanphamSize _tkho;
		IMau _mau; IKhuyenMai kmRepo;
		public FavouriteProductsController(ISanpham productDetail, IDongSanpham product, ISize sz, ISanphamSize tkho, IMau mau, IKhuyenMai kmRepo)
		{
			sanphamrepo = productDetail;
			_product = product;
			_size = sz;
			_tkho = tkho;
			_mau = mau;
			this.kmRepo = kmRepo;
		}

		public IActionResult ViewFavouriteProducts()
		{
			var FavouriteItems = HttpContext.Session.Get<List<FavouriteProductsItem>>("Favourite") ?? new List<FavouriteProductsItem>();

			return View(FavouriteItems);
		}

		[Route("FavouriteProducts/AddFavouriteProducts/{id}/{tenSize}/{slton}")]
		public IActionResult AddFavouriteProducts(int id, string tenSize, int slton)
		{
			Sanpham sp = sanphamrepo.Getsanpham(id);

			var FavouriteItems = HttpContext.Session.Get<List<FavouriteProductsItem>>("Favourite") ?? new List<FavouriteProductsItem>();
			var existingFavouriteItems = FavouriteItems.FirstOrDefault(item => item.sanpham.Masp == id && item.Size == tenSize);

			if (existingFavouriteItems != null)
			{
				if (existingFavouriteItems.Quantity <= slton - 1)
				{
                    existingFavouriteItems.Quantity += 1;
				}
				else
				{
					return RedirectToAction("HienThiSanPham", "SanPham", new { madongsanpham = sp.Madongsanpham, masp = sp.Masp });
				}
			}
			else
			{
				Dongsanpham dongSanPham = _product.GetDongSanpham(sp.Madongsanpham);
				Mau mau = _mau.GetMau(sp.Mamau);

                FavouriteItems.Add(new FavouriteProductsItem()
				{
					sanpham = sp,
					Name = dongSanPham.Tendongsp,
					TenMau = mau.Tenmau,
					Quantity = 1,
					tonkho = slton,
					GiaGoc = dongSanPham.Giagoc,
					PhanTramGiam = kmRepo.GetKmProductToday(dongSanPham),
					Size = tenSize,
					Maspsize = _tkho.GetMaspsize(sp.Masp, tenSize)
				});
			}
			HttpContext.Session.Set("Favourite", FavouriteItems); 

			return RedirectToAction("ViewFavouriteProducts");
		}

		public IActionResult IncreaseFP(int Masp, string size) 
		{
			var FavouriteItems = HttpContext.Session.Get<List<FavouriteProductsItem>>("Favourite");
			FavouriteProductsItem shopFPIncrease = FavouriteItems
                .FirstOrDefault(x => x.sanpham.Masp == Masp && x.Size == size);

			if (shopFPIncrease.tonkho >= shopFPIncrease.Quantity + 1)
			{
                shopFPIncrease.Quantity += 1;
			}

			HttpContext.Session.Set("Favourite", FavouriteItems);
			return RedirectToAction("ViewFavouriteProducts");
		}


		public IActionResult DecreaseFP(int Masp, string size)
		{
			var FavouriteItems = HttpContext.Session.Get<List<FavouriteProductsItem>>("Favourite");
			FavouriteProductsItem shopFPDecrease = FavouriteItems
				.FirstOrDefault(x => x.sanpham.Masp == Masp && x.Size == size);

            shopFPDecrease.Quantity -= 1;
			if (shopFPDecrease.Quantity == 0)
			{
                FavouriteItems.Remove(shopFPDecrease);
			}
			HttpContext.Session.Set("Favourite", FavouriteItems);

			return RedirectToAction("ViewFavouriteProducts");
		}

		public IActionResult DeleteFP(int Masp, string tenSize)
		{

			var FavouriteItems = HttpContext.Session.Get<List<FavouriteProductsItem>>("Favourite");
			FavouriteProductsItem shopFPDelete = FavouriteItems
                .FirstOrDefault(x => x.sanpham.Masp == Masp && x.Size == tenSize);

			if (shopFPDelete != null)
			{
                FavouriteItems.Remove(shopFPDelete);
			}

			HttpContext.Session.Set("Favourite ", FavouriteItems);

			return RedirectToAction("ViewFavouriteProducts");

		}


	}
}
