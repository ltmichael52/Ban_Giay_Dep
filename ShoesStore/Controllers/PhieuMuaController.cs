//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using ShoesStore.InterfaceRepositories;
//using ShoesStore.Models;
//using ShoesStore.Models.Authentication;
//using ShoesStore.Models.Session;
//using ShoesStore.Repositories;
//using ShoesStore.ViewModels;
//using System.Diagnostics;

//namespace ShoesStore.Controllers
//{
//    public class PhieuMuaController : Controller
//    {
//        IKhachhang khRepo; IPhuongthucthanhtoan pttt; ISanphamSize spsize; IPhieuMua pm; IEmailSender emailSender;
//        public PhieuMuaController(IKhachhang kh,IPhuongthucthanhtoan pt,ISanphamSize sizesp,IPhieuMua pm2,IEmailSender email)
//        {
//            this.khRepo = kh;
//            this.pttt = pt;
//            spsize = sizesp;
//            pm = pm2;
//            emailSender = email;
//        }

//        public IActionResult ThanhToan()
//        {
//            if (HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") == null)
//            {
//                return RedirectToAction("SanPhamTheoLoai", "SanPham", new { maloai = -1 });
//            }
//            if (HttpContext.Session.GetString("Email") == null || HttpContext.Session.GetString("Loaitk") != "0")
//            {
//                TempData["ThanhToan"] = "Vui lòng đăng nhập trước khi thanh toán";
//                return RedirectToAction("Login","Account");
//            }
//            string emailkh = HttpContext.Session.GetString("Email") ?? "lephat@gmail.com";
//            Khachhang kh = khRepo.GetCurrentKh(emailkh);
//            PhieuMuaViewModel phieuMua = new PhieuMuaViewModel()
//            {
//                listcartItem = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>(),
//                khInfo = kh,
//                Mapttt = 0
//            };


//            ViewBag.MethodPurchase = pttt.GetAllPttt();
//            return View(phieuMua);
//        }

//        [HttpPost]
//        public IActionResult ThanhToan(PhieuMuaViewModel phieuMua)
//        {

//            phieuMua.listcartItem = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
//            ViewBag.MethodPurchase = pttt.GetAllPttt();
            
//            if (Check(phieuMua) == true)
//            {
//                return View(phieuMua);
//            }
//            spsize.MinusSanPhamSize(phieuMua);
//            pm.AddPhieuMua(phieuMua);
//            khRepo.UpdateKh(phieuMua.khInfo);

//			HttpContext.Session.Remove("Cart");

//			string receiver = "lephat011104@gmail.com";
//			string subject = "New Order Success";
//			string message = "ORDER ID: ";
//			emailSender.SendEmail(receiver, subject, message);

//			return RedirectToAction("Confirmation", "PhieuMua");
//        }


//        public IActionResult Confirmation()
//        {
			
//			return View();
//        }


//        public bool Check(PhieuMuaViewModel phieuMua)
//        {
//            bool check = false;
//            if (string.IsNullOrEmpty(phieuMua.khInfo.Diachi))
//            {
//                Debug.WriteLine("Get in thanh toan post in check null");
//                ModelState.AddModelError("khInfo.Diachi", "Vui lòng nhập địa chỉ");
//                check = true;
//            }
//            if (phieuMua.Mapttt == null || phieuMua.Mapttt == 0)
//            {
//                ModelState.AddModelError("Mapttt", "Vui lòng chọn phương thức thanh toán");
//                check = true;
//            }
//            return check;
//        }
//    }
//}
