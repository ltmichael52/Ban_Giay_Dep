using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.Models.Authentication;
using ShoesStore.Models.Session;
using ShoesStore.Repositories;
using ShoesStore.ViewModels;
using System.Diagnostics;

namespace ShoesStore.Controllers
{
    public class PhieuMuaController : Controller
    {
        IKhachhang khRepo; IPhuongthucthanhtoan pttt; ISanphamSize spsize; IPhieuMua pm; IEmailSender emailSender; IAddressNoteBook addressRepo;
        public PhieuMuaController(IKhachhang kh, IPhuongthucthanhtoan pt, ISanphamSize sizesp, IPhieuMua pm2, IEmailSender email
            ,IAddressNoteBook addressRepo)
        {
            this.khRepo = kh;
            this.pttt = pt;
            spsize = sizesp;
            pm = pm2;
            emailSender = email;
            this.addressRepo = addressRepo;
        }

        public IActionResult ThanhToan()
        {
            //if (HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") == null)
            //{
            //    return RedirectToAction("SanPhamTheoLoai", "SanPham", new { maloai = -1 });
            //}
            //if (HttpContext.Session.GetString("Email") == null || HttpContext.Session.GetString("Loaitk") != "0")
            //{
            //    TempData["ThanhToan"] = "Please login before checkout";
            //    return RedirectToAction("Login", "Account");
            //}
            string emailkh = HttpContext.Session.GetString("Email") ?? "lephat@gmail.com";
            Khachhang kh = khRepo.GetCurrentKh(emailkh);
            PhieuMuaViewModel phieuMua = new PhieuMuaViewModel()
            {
                listcartItem = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>(),
                khInfo = kh,
                Mapttt = 0,
                sodiachis = addressRepo.GetAllAddressNote(),
            };

            ViewBag.MethodPurchase = pttt.GetAllPttt();
            return View(phieuMua);
        }

        [HttpPost]
        public IActionResult ThanhToan(PhieuMuaViewModel phieuMua)
        {

            phieuMua.listcartItem = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            ViewBag.MethodPurchase = pttt.GetAllPttt();

            if (Check(phieuMua) == true)
            {
                return View(phieuMua);
            }
            spsize.MinusSanPhamSize(phieuMua);
            pm.AddPhieuMua(phieuMua);
            khRepo.UpdateKh(phieuMua.khInfo);

            HttpContext.Session.Remove("Cart");

            string receiver = "lephat011104@gmail.com";
            string subject = "New Order Success";
            string message = "ORDER ID: ";
            emailSender.SendEmail(receiver, subject, message);

            return RedirectToAction("Confirmation", "PhieuMua");
        }

        public IActionResult AddressNoteBook()
        {

            PhieuMuaViewModel pm = new PhieuMuaViewModel();
            List<Tinh> tinhList = addressRepo.GetTinhList();
            List<SelectListItem> selectTinh = tinhList.Select(x => new SelectListItem
            {
                Value = x.Matinh.ToString(),
                Text = x.Tentinh
            }).ToList();

            ViewBag.SelectTinh = selectTinh;

            Khachhang kh = khRepo.GetCurrentKh("lephat@gmail.com");
            pm.khInfo = kh;

            pm.sodiachis = addressRepo.GetAllAddressNote();

            return View(pm);
        }

        public IActionResult AddAddress(int province,int district,int ward,string address,int makh,string tennguoinhan,string sdtnguoinhan)
        {
            addressRepo.AddAddressNote(province, district, ward, address, makh, tennguoinhan, sdtnguoinhan);
            return RedirectToAction("AddressNoteBook");
        }

        public IActionResult GetDistinctsByProvince(int provinceId)
        {
            List<Quan> quanList = addressRepo.GetQuanList(provinceId);
            List<SelectListItem> selectQuan = quanList.Select(x => new SelectListItem
            {
                Value = x.Maquan.ToString(),
                Text = x.Tenquan
            }).ToList();
            return Json(selectQuan);
        }

        public IActionResult GetWardByDistrict(int districtId)
        {
            List<Phuong> phuongList = addressRepo.GetPhuongList(districtId);
            List<SelectListItem> selectPhuong = phuongList.Select(x => new SelectListItem
            {
                Value = x.Maphuong.ToString(),
                Text = x.Tenphuong
            }).ToList();
            return Json(selectPhuong);
        }

        public IActionResult Confirmation()
        {

            return View();
        }


        public bool Check(PhieuMuaViewModel phieuMua)
        {
            bool check = false;
            //if (string.IsNullOrEmpty(phieuMua.khInfo.Diachi))
            //{
            //    Debug.WriteLine("Get in thanh toan post in check null");
            //    ModelState.AddModelError("khInfo.Diachi", "Vui lòng nhập địa chỉ");
            //    check = true;
            //}
            if (phieuMua.Mapttt == null || phieuMua.Mapttt == 0)
            {
                ModelState.AddModelError("Mapttt", "Vui lòng chọn phương thức thanh toán");
                check = true;
            }
            return check;
        }
    }
}
