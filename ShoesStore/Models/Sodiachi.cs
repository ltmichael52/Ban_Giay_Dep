namespace ShoesStore.Models
{
    public class Sodiachi
    {
        public int Masodiachi {  get; set; }
        public int Makh { get; set; }
        public string Tennguoinhan {  get; set; } = null!;
        public string Sdtnguoinhan { get; set; } = null!;
        public string Diachi { get; set; } = null!;

        public virtual Khachhang MakhNavigation {  get; set; }

    }
}
