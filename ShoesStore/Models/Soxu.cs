namespace ShoesStore.Models
{
    public class Soxu
    {
        public int Masoxu { get; set; }
        public int Makh {  get; set; }
        public decimal Tongxu {  get; set; }

        public virtual Khachhang MakhNavigation {  get; set; }
    }
}
