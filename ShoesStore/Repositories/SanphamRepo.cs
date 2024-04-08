using Microsoft.EntityFrameworkCore;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.ViewModels;
using System.Collections.Generic;

namespace ShoesStore.Repositories
{
    public class SanphamRepo : ISanpham
    {
        ShoesDbContext _context;
        public SanphamRepo(ShoesDbContext context)
        {
            _context = context;
        }

        public Sanpham Getsanpham(int masp)
        {
			Sanpham sp = _context.Sanphams.FirstOrDefault(x => x.Masp == masp);
            return sp;

        }
		public SanphamViewModel HienThiSanpham(int madongsanpham, int masp)
        {
			DateTime today = DateTime.Now.Date;
			Dongsanpham dongsp = _context.Dongsanphams.FirstOrDefault(x => x.Madongsanpham == madongsanpham);

			Khuyenmai KmTodayThatdsp = _context.Khuyenmais.Include(x => x.Madongsanphams)
											.ThenInclude(d => d.Makms)
											.FirstOrDefault(a => a.Ngaybd <= today && today < a.Ngaykt && a.Madongsanphams.Any(k => k.Madongsanpham == madongsanpham));

			dongsp.Makms.Add(KmTodayThatdsp);

			List < Sanpham > sp = _context.Sanphams.
				Where(x => x.Masp != masp && x.Madongsanpham == madongsanpham)
				.ToList();
			Sanpham ctFirst = _context.Sanphams.FirstOrDefault(x => x.Masp == masp);

			ctFirst.MamauNavigation = _context.Maus.FirstOrDefault(x => x.Mamau == ctFirst.Mamau);
			sp.Insert(0, ctFirst);

			SanphamViewModel pDetail = new SanphamViewModel
			{
				dongsanpham = dongsp,
				sanphams = sp,
				tenSize = _context.Sizes
					.Select(x => x.Tensize).ToList(),
				slton = _context.Sanphamsizes
						.Where(x => x.Masp == masp)
						.Select(x => x.Slton).ToList()
			};

			return pDetail;
		}
	}
}
