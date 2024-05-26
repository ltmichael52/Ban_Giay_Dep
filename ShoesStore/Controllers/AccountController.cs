using Microsoft.AspNetCore.Mvc;
using ShoesStore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using ShoesStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Repositories;

namespace ShoesStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShoesDbContext _db;IAddressNoteBook addressRepo; IKhachhang khRepo;

        // Constructor injection để inject ShoesDbContext vào Controller
        public AccountController(ShoesDbContext db,IAddressNoteBook addressRepo,IKhachhang khRepo)
        {
            _db = db;
            this.addressRepo = addressRepo;
            this.khRepo = khRepo;
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
        public IActionResult AddAddress(int province, int district, int ward, string address, string tennguoinhan, string sdtnguoinhan)
        {
            string email = HttpContext.Session.GetString("Email") ?? "lephat@gmail.com";
            Khachhang kh = khRepo.GetCurrentKh(email);
            addressRepo.AddAddressNote(province, district, ward, address, kh.Makh, tennguoinhan, sdtnguoinhan);
            List<Sodiachi> sdc = addressRepo.GetAllAddressNote();
            return PartialView("AddressBookPartialView",sdc);
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

        public IActionResult UserProfile()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            //if (HttpContext.Session.GetString("Email") == null)
            //{
            //    // Nếu chưa đăng nhập, chuyển hướng đến trang Login
            //    return RedirectToAction("Login", "Account");
            //}

            // Lấy thông tin tài khoản khách hàng từ Session
            string userEmail = /*HttpContext.Session.GetString("Email")*/ "lephat@gmail.com";
            var user = _db.Taikhoans
                            .Include(t => t.Khachhang)
                            .FirstOrDefault(x => x.Email == userEmail);

            if (user != null)
            {
                return View(user.Khachhang);
            }

            // Nếu không tìm thấy thông tin, chuyển hướng về trang Home
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Getuserprofile()
        {
            return ViewComponent("UserProfile");
        }

        public IActionResult AddressBook()
        {
            return ViewComponent("AddressBook");
        }

        // GET: /Account/ChangeProfile
        public IActionResult ChangeProfile()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            ////if (HttpContext.Session.GetString("Email") == null)
            ////{
            ////    // Nếu chưa đăng nhập, chuyển hướng đến trang Login
            ////    return RedirectToAction("Login", "Account");
            ////}

            // Lấy thông tin tài khoản khách hàng từ Session
            string userEmail = /*HttpContext.Session.GetString("Email") ??*/ "lephat@gmail.com";
            var user = _db.Taikhoans
                            .Include(t => t.Khachhang)
                            .FirstOrDefault(x => x.Email == userEmail);

            if (user != null)
            {
                return View(user.Khachhang);
            }

            // Nếu không tìm thấy thông tin, chuyển hướng về trang Home
            return RedirectToAction("Index", "Home");
        }

        //[ValidateAntiForgeryToken]
        public IActionResult ChangeProfileUpdate(string tenkh, string sdt, bool gioitinh, DateTime? ngaysinh)
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            //if (HttpContext.Session.GetString("Email") == null)
            //{
            //    // Nếu chưa đăng nhập, chuyển hướng đến trang Login
            //    return RedirectToAction("Login", "Account");
            //}

            // Lấy email của người dùng từ Session
            string userEmail = /*HttpContext.Session.GetString("Email")*/ "lephat@gmail.com";

            // Tìm thông tin khách hàng dựa trên email
            var customer = _db.Khachhangs.FirstOrDefault(kh => kh.Email == userEmail);

            if (customer != null)
            {
                // Cập nhật thông tin khách hàng
                customer.Tenkh = tenkh;
                customer.Sdt = sdt;
                customer.Gioitinh = gioitinh;
                customer.Ngaysinh = ngaysinh;

                _db.Khachhangs.Update(customer);
                _db.SaveChanges();

                // Trả về JSON hoặc thông báo thành công
                return PartialView("PartialViewProfileInfo", customer);
            }

            // Nếu không tìm thấy thông tin, trả về thông báo lỗi
            return Json(new { success = false });
        }

        public IActionResult OrderHistory()
        {
            return ViewComponent("OrderHistory");
        }
    }
}
