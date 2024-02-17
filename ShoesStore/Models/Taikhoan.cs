using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Taikhoan
{
    public string Email { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public int Loaitk { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
