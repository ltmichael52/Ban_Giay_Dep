using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.ViewModels;

namespace ShoesStore.Repositories
{
    public class BinhLuanRepository : IBinhLuan
    {
        private readonly ShoesDbContext _context;

        public BinhLuanRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Binhluan> LayTatCa()
        {
            return _context.Binhluans.OrderBy(x => x.Ngaybl);
        }

        public void AddBinhLuan(Binhluan bl)
        {
            _context.Binhluans.Add(bl);
            _context.SaveChanges();
        }

	}
}
