namespace ShoesStore.Models
{
    public class Phuong
    {
        public int Maphuong {  get; set; }
        public string Tenphuong {  get; set; }
        public int Maquan {  get; set; }

        public virtual Quan MaquanNavigation {  get; set; }
    }
}
