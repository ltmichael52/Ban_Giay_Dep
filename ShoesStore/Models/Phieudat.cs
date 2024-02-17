using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Phieudat
{
    public int Idpd { get; set; }

    public DateTime Ngaydat { get; set; }

    public int Idkh { get; set; }

    public int? Idnv { get; set; }

    public string Tinhtrang { get; set; } = null!;

    public string Phuongthucthanhtoan { get; set; } = null!;

    public string? Ghichu { get; set; }

    public string? Lydohuydon { get; set; }

    public virtual ICollection<Chitietphieudat> Chitietphieudats { get; set; } = new List<Chitietphieudat>();

    public virtual Khachhang IdkhNavigation { get; set; } = null!;

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
