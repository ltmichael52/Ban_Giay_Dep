using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Sanpham
{
    public int Idsp { get; set; }

    public int Idloai { get; set; }

    public string Tensp { get; set; } = null!;

    public string Hinhanh { get; set; } = null!;

    public int Soluong { get; set; }

    public decimal Giagoc { get; set; }

    public decimal? Giasale { get; set; }

    public string Mau { get; set; } = null!;

    public string Size { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public bool? Hienthi { get; set; }

    public bool? Hethang { get; set; }

    public bool? Giamgia { get; set; }

    public bool? Moi { get; set; }

    public bool? Hot { get; set; }

    public virtual ICollection<Chitietphieudat> Chitietphieudats { get; set; } = new List<Chitietphieudat>();

    public virtual Loai IdloaiNavigation { get; set; } = null!;
}
