using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ShoesStore.Models;

namespace ShoesStore.ViewComponents
{
	public class ShowCommentViewComponent : ViewComponent
	{
		private readonly ShoesDbContext _context;

		public ShowCommentViewComponent(ShoesDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			int Masp = HttpContext.Session.GetInt32("Masp") ?? 0;
			Sanpham sp = _context.Sanphams.Find(Masp);
			int Madongsanpham = _context.Dongsanphams.FirstOrDefault(x => x.Madongsanpham == sp.Madongsanpham).Madongsanpham;
			var listofComment = _context.Binhluans
				.Where(objComment => objComment.Madongsanpham == Madongsanpham)
				.Select(x => new Binhluan
				{
					Makh = x.Makh,
					MakhNavigation = x.MakhNavigation,
					Ngaybl = x.Ngaybl,
					Rating = x.Rating,
					Noidungbl = x.Noidungbl
				})
				.ToList();
			TempData["Comment"] = "Vui lòng đăng nhập trước khi comment";
			return View(listofComment);
		}
	}
}
