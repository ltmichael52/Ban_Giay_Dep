using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;

namespace ShoesStore.Repositories
{
    public class AddressNoteBookRepo : IAddressNoteBook
    {
        ShoesDbContext context;
        public AddressNoteBookRepo(ShoesDbContext context)
        {
            this.context = context;
        }
        public List<Tinh> GetTinhList()
        {
            return context.Tinhs.ToList();
        }
        public List<Quan> GetQuanList(int provinces)
        {
            return context.Quans.Where(x=>x.Matinh == provinces).ToList();
        }
        public List<Phuong> GetPhuongList(int districts)
        {
            return context.Phuongs.Where(x => x.Maquan == districts).ToList();
        }

        public List<Sodiachi> GetAllAddressNote()
        {
            return context.Sodiachis.ToList();
        }

        public void AddAddressNote(int proviceId, int districtId, int wardId,string address,int makh,string tennguoinhan,string sdt)
        {
            Tinh province = context.Tinhs.Find(proviceId);
            Quan district = context.Quans.Find(districtId);
            Phuong ward = context.Phuongs.Find(wardId);

            string finalAddress = address + ", "+province.Tentinh + ", "+district.Tenquan + ", "+ward.Tenphuong;

            Sodiachi sdc = new Sodiachi
            {
                Tennguoinhan = tennguoinhan,
                Sdtnguoinhan = sdt,
                Makh = makh,
                Diachi = finalAddress
            };

            context.Sodiachis.Add(sdc);
            context.SaveChanges();
        }
    }
}
