namespace ShoesStore.Models
{
    public class Tinh
    {
        public int Matinh {  get; set; }
        public string Tentinh { get; set; }

        public virtual ICollection<Quan> Quans { get; set; }
    }
}
