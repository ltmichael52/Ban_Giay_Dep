using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.ViewModels;
using System.Diagnostics;
using X.PagedList;

namespace ShoesStore.Controllers
{
	public class SanPhamController : Controller
	{
        IHttpContextAccessor httpcontextAcc; IBinhLuan blRepo;
		 IDongSanpham dongspRepo;ISanpham spRepo; IMau mauRepo; IKhachhang khRepo;
		public SanPhamController(ShoesDbContext context, IDongSanpham dongspRepo, ISanpham spRepo, IMau m,
			IHttpContextAccessor httpcontextAcc, IKhachhang khRepo,IBinhLuan blRepo)
		{
			this.dongspRepo = dongspRepo;
			this.spRepo = spRepo;
			this.mauRepo = m;
			this.httpcontextAcc = httpcontextAcc;
			this.khRepo = khRepo;
			this.blRepo = blRepo;
		}	
		public IActionResult SanPhamTheoLoai(string? searchString, string? maMau, int? sortGia, decimal? minPrice, decimal? maxPrice,int maLoai)
		{
			CreateData();

			ViewBag.maLoai = maLoai;
			ViewBag.sortGia1 = sortGia;
			ViewBag.maMau1 = maMau;
			ViewBag.searchString1 = searchString;
			ViewBag.minPrice1 = minPrice;
			ViewBag.maxPrice1 = maxPrice;
			TempData["AddCategoryId"] = "true";

			List<DongsanphamViewModel> dongspview = dongspRepo.GetDongspView(maMau,sortGia,searchString,minPrice,maxPrice,maLoai);

			if (IsAjaxRequest())
			{
				return PartialView("_PartialSanPhamTheoLoai", dongspview);
			}

			else
			{
				return View(dongspview);
			}
			
		}

		private bool IsAjaxRequest()
		{
			var request = httpcontextAcc.HttpContext.Request;
			return request.Headers["X-Requested-With"] == "XMLHttpRequest";
		}

		public IActionResult HienThiSanpham(int madongsanpham, int masp)
		{
			SanphamViewModel pDetail = spRepo.HienThiSanpham(madongsanpham, masp);
            HttpContext.Session.SetInt32("Masp",masp);
            return View(pDetail);
		}

		public void CreateData()
		{
			List<SelectListItem> MauList = mauRepo.GetMauList().Select(x=> new SelectListItem
			{
				Value = x.Mamau,
				Text = x.Tenmau
			}).ToList();
			ViewBag.MauList = MauList;
		}

        [HttpPost]
        public IActionResult AddComment(int rating, string SanPhamComment)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int Masp = HttpContext.Session.GetInt32("Masp") ?? 0;
            Sanpham sp = spRepo.Getsanpham(Masp);
            string userEmail = HttpContext.Session.GetString("Email");
			var user = khRepo.GetCurrentKh(userEmail);

            if (user == null)
            {
                return NotFound();
            }

			int makh = user.Makh;

            Binhluan objComment = new Binhluan
            {
                Madongsanpham = sp.Madongsanpham,
                Noidungbl = SanPhamComment,
                Ngaybl = DateTime.Now,
                Makh = makh,
				Rating = rating
			};

			blRepo.AddBinhLuan(objComment);

            return RedirectToAction("HienThiSanpham", new { madongsanpham = sp.Madongsanpham, masp = Masp });
        }
    }
}
