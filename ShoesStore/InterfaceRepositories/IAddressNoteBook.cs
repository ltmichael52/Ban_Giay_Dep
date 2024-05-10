using ShoesStore.Models;

namespace ShoesStore.InterfaceRepositories
{
    public interface IAddressNoteBook
    {
        public List<Tinh> GetTinhList();
        public List<Quan> GetQuanList(int provinces);
        public List<Phuong> GetPhuongList(int districts);
        public List<Sodiachi> GetAllAddressNote();
        public void AddAddressNote(int proviceId, int districtId, int wardId, string address,int makh, string tennguoinhan, string sdt);
    }
}
