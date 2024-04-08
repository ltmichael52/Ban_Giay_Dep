using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesStore.Areas.Admin.InterfaceRepositories;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;
using ShoesStore.Models.Authentication;
using System.Security.Claims;

namespace ShoesStore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PhieuMuaAdminController : Controller
    {
        private readonly IPhieuMuaAdmin _pmrepo;
        ShoesDbContext _db;
        public PhieuMuaAdminController(IPhieuMuaAdmin pmrepo, ShoesDbContext db)
        {
            _pmrepo = pmrepo;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_pmrepo.GetAllPhieuMua().ToList());
        }

        public IActionResult Edit(int id)
        {
            Phieumua phieuMua = _pmrepo.GetPhieuMuaById(id);

            // Get the current user's email from claims
            var currentUserEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            // Find the employee associated with the current user's email
            var currentEmployee = _db.Nhanviens.FirstOrDefault(e => e.Email == currentUserEmail);

            // If the current employee is found, set the Manv field
            if (currentEmployee != null)
            {
                phieuMua.Manv = currentEmployee.Manv;
            }

           /* ViewBag.SelectKhachhang = new SelectList(_db.Khachhangs, "Makh", "Tenkh", phieuMua.Makh);
            ViewBag.SelectNhanVien = new SelectList(_db.Nhanviens, "Manv", "Tennv", phieuMua.Manv);
            ViewBag.SelectPTTT = new SelectList(_db.Phuongthucthanhtoans, "Mapttt", "Tenphuongthuc", phieuMua.Mapttt);
*/
            return View(phieuMua); // Trả về view edit với dữ liệu phiếu mua
        }

        // POST: /Admin/PhieuMuaAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Phieumua phieuMua)
        {

            _pmrepo.UpdatePhieuMua(phieuMua, id); 
            return RedirectToAction(nameof(Index));
          
        }

        public IActionResult Partial_SanPham(int id)
        {
            var items = _db.Chitietphieumuas.Where(x => x.Mapm == id).ToList();
            return PartialView(items);
        }
    }
}
