using Microsoft.AspNetCore.Mvc;
using ShoesStore.Areas.Admin.InterfaceRepositories;
using ShoesStore.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ShoesStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogAdminController : Controller
    {
        private readonly IBlogAdmin _blogAdmin;

        public BlogAdminController(IBlogAdmin blogAdmin)
        {
            _blogAdmin = blogAdmin;
        }

        [HttpGet]
        public async Task<IActionResult> DetailBlog(int Mablog)
        {
            // Retrieve the blog details
            Blog blog = await _blogAdmin.GetBlog(Mablog);

            // Pass the blog details to the view
            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> ListBlogs()
        {
            // Retrieve list of blogs
            List<Blog> blogs = await _blogAdmin.GetBlogs();

            // Pass the list of blogs to the view
            return View(blogs);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            
            // Return the empty form for adding a new blog
             return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks
        //public async Task<IActionResult> AddBlog(Blog blog)
        //{
        //    blog.ManvNavigation = null;
        //    // Check if model state is valid
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Lấy giá trị Manv từ session và gán vào đối tượng Blog
        //            int? manv = HttpContext.Session.GetInt32("Manv");
        //            if (manv.HasValue)
        //            {
        //                blog.Manv = manv.Value;
        //            }
        //            else
        //            {
        //                // Handle the case where Manv is not available in session
        //                ModelState.AddModelError("", "Mã nhân viên không tồn tại.");
        //                return View(blog);
        //            }

        //            // Add the new blog to the database
        //            int addedBlogId = await _blogAdmin.AddBlog(blog);
        //            if (addedBlogId > 0)
        //            {
        //                // Blog added successfully, redirect to the list of blogs
        //                return RedirectToAction(nameof(ListBlogs));
        //            }
        //            else
        //            {
        //                // Handle error if the blog was not added successfully
        //                ModelState.AddModelError("", "Error occurred while adding the blog.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log exception or handle it appropriately
        //            ModelState.AddModelError("", "An error occurred: " + ex.Message);
        //        }
        //    }

        //    // If we're here, there are validation errors or an exception occurred, return the AddBlog view with errors
        //    return View(blog);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks
        public async Task<IActionResult> AddBlog(Blog blog)
        {
            blog.ManvNavigation = null;
            // Check if model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Add the new blog to the database
                    int addedBlogId = await _blogAdmin.AddBlog(blog);
                    if (addedBlogId > 0)
                    {
                        // Blog added successfully, redirect to the list of blogs
                        return RedirectToAction(nameof(ListBlogs));
                    }
                    else
                    {
                        // Handle error if the blog was not added successfully
                        ModelState.AddModelError("", "Error occurred while adding the blog.");
                    }
                }
                catch (Exception ex)
                {
                    // Log exception or handle it appropriately
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                }
            }

            // If we're here, there are validation errors or an exception occurred, return the AddBlog view with errors
            return View(blog);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int Mablog)
        {
            Blog blog = await _blogAdmin.GetBlog(Mablog);
            if (blog == null)
            {
                return NotFound(); // Return 404 if blog not found
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            blog.ManvNavigation = null;
            if (ModelState.IsValid)
            {
                bool isUpdated = await _blogAdmin.UpdateBlog(blog);
                if (isUpdated)
                {
                    return RedirectToAction(nameof(ListBlogs)); // Redirect to ListBlogs action if updated successfully
                }
                else
                {
                    return View("Error"); // Handle error
                }
            }
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int Mablog)
        {
            bool isDeleted = await _blogAdmin.DeleteBlog(Mablog);
            if (isDeleted)
            {
                // Blog deleted successfully
                return RedirectToAction(nameof(ListBlogs)); // Redirect to ListBlogs action
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }

       
    }
}
