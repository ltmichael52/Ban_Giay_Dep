namespace ShoesStore.Models
{
    public class Quan
    {
        public int Maquan {  get; set; }
        public string Tenquan {  get; set; }
        public int Matinh { get; set; }

        public virtual Tinh MatinhNavigation { get; set; }
        public virtual ICollection<Phuong> Phuongs { get; set; }
    }
}
