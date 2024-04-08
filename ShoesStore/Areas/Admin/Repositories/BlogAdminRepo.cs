using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoesStore.Areas.Admin.InterfaceRepositories;
using ShoesStore.Models;

namespace ShoesStore.Areas.Admin.Repositories
{
    public class BlogAdminRepo : IBlogAdmin
    {
        private readonly ShoesDbContext _context;

        public BlogAdminRepo(ShoesDbContext context)
        {
            _context = context;
        }
        public async Task<Blog> GetBlog(int Mablog)
        {
            return await _context.Blogs.FindAsync(Mablog);
        }
        public async Task<List<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<int> AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog.Mablog; // Return the ID of the added blog
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(blog.Mablog))
                {
                    return false; // Blog not found
                }
                else
                {
                    throw;
                }
            }
            return true; // Updated successfully
        }

        public async Task<bool> DeleteBlog(int Mablog)
        {
            var blog = await _context.Blogs.FindAsync(Mablog);
            if (blog == null)
            {
                return false; // Blog not found
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true; // Deleted successfully
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Mablog == id);
        }
    }
}
