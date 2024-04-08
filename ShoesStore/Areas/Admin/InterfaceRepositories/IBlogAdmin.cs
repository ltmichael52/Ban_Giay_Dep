
using global::ShoesStore.Models;

namespace ShoesStore.Areas.Admin.InterfaceRepositories
{
    public interface IBlogAdmin
    {
        Task<List<Blog>> GetBlogs(); 
        Task<int> AddBlog(Blog blog);
        Task<bool> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(int Mablog);
        Task<Blog> GetBlog(int Mablog);

    }
}
