namespace ShoesStore.Models
{
    public class Voucher
    {
        public int Mavoucher {  get; set; }
        public int Soluong {  get; set; }
        public int Phantramgiam { get; set; }
        public decimal Giatoithieu {  get; set; }
        public decimal Giamtoida {  get; set; }
        public DateTime Ngaytao { get; set; }
        public DateTime Ngayhethan {  get; set; }

        public virtual ICollection<Phieumua> Phieumuas { get; set; }
    }
}
