using Microsoft.AspNetCore.Mvc;
using ShoesStore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using ShoesStore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ShoesStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShoesDbContext _db;

        // Constructor injection để inject ShoesDbContext vào Controller
        public AccountController(ShoesDbContext db)
        {
            _db = db;
        }

        public IActionResult Register()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (HttpContext.Session.GetString("Email") != null && HttpContext.Session.GetString("Loaitk") == "0")
            {
                // Nếu đã đăng nhập, chuyển hướng đến trang Home
                return RedirectToAction("Index", "Home");
            }

            // Nếu chưa đăng nhập, hiển thị trang đăng ký
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            Taikhoan existEmail = _db.Taikhoans.FirstOrDefault(x => x.Email == model.Khachhang.Email);
            if (existEmail != null)
            {
                ModelState.AddModelError("Khachhang.Email", "Đã tồn tại email");
                return View(model);
            }
            Taikhoan newTk = new Taikhoan
            {
                Email = model.Khachhang.Email,
                Matkhau = model.Taikhoan.Matkhau,
                Loaitk = 0
            };
            // Lưu đối tượng Khachhang vào cơ sở dữ liệu
            model.Taikhoan = newTk; // Đảm bảo email giữa Khachhang và Taikhoan khớp nhau
            model.Khachhang.EmailNavigation = newTk;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Lưu đối tượng Taikhoan vào cơ sở dữ liệu
            _db.Taikhoans.Add(model.Taikhoan);

            _db.Khachhangs.Add(model.Khachhang);
            _db.SaveChanges();

            // Chuyển hướng đến trang Home
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (HttpContext.Session.GetString("Email") == null || HttpContext.Session.GetString("Loaitk") != "0")
            {
                // Nếu chưa đăng nhập, hiển thị trang đăng nhập
                return View();
            }
            else
            {
                // Nếu đã đăng nhập, chuyển hướng đến trang Home
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Taikhoan taikhoan, int thanhtoan, int comment)
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (HttpContext.Session.GetString("Email") == null || HttpContext.Session.GetString("Loaitk") != "0")
            {
                // Tìm kiếm tài khoản trong cơ sở dữ liệu
                var user = _db.Taikhoans.FirstOrDefault(x => x.Email == taikhoan.Email && x.Matkhau == taikhoan.Matkhau && x.Loaitk == 0);

                if (user != null)
                {
                    // Lưu thông tin người dùng vào Session
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Loaitk", user.Loaitk.ToString());

                    if (thanhtoan == 1)
                    {
                        return RedirectToAction("ThanhToan", "PhieuMua");
                    }
                    //if (comment == 1)
                    //{
                    //	return RedirectToAction("HienThiSanPham", "SanPham");
                    //}
                    // Chuyển hướng đến trang Home
                    return RedirectToAction("Index", "Home");
                }
            }
            if (thanhtoan == 1)
            {
                TempData["ThanhToan"] = "Vui lòng đăng nhập trước khi thanh toán";
            }
            //if (comment == 1)
            //{
            //    TempData["Comment"] = "Vui lòng đăng nhập trước khi comment";
            //}
            // Nếu thông tin không hợp lệ, hiển thị lại trang đăng nhập với thông báo lỗi
            return View(taikhoan);
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // Xóa thông tin người dùng khỏi Session
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Email");

            // Chuyển hướng đến trang Login
            return RedirectToAction("Login", "Account");
        }
    }
}
