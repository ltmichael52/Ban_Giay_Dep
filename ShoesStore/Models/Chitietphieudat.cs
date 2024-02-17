using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Chitietphieudat
{
    public int Idpd { get; set; }

    public int Idsp { get; set; }

    public decimal Tongtien { get; set; }

    public int? Soluong { get; set; }

    public virtual Phieudat IdpdNavigation { get; set; } = null!;

    public virtual Sanpham IdspNavigation { get; set; } = null!;
}
