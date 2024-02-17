using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Loai
{
    public int Idloai { get; set; }

    public string Tenloai { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
