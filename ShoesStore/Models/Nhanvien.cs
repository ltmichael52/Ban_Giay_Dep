﻿using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Nhanvien
{
    public int Idnv { get; set; }

    public string Tennv { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public bool Gioitinh { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public virtual Taikhoan EmailNavigation { get; set; } = null!;

    public virtual ICollection<Phieudat> Phieudats { get; set; } = new List<Phieudat>();
}
