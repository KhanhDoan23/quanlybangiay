using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class GiayBUS
    {
        private GiayDAL GiayDAL = new GiayDAL();
        public List<GiayDTO> LayDanhSachGiay()
        {
            return GiayDAL.LayDanhSachGiay();
        }
        public bool ThemGiay(GiayDTO Giay)
        {
            return GiayDAL.ThemGiay(Giay);
        }
        public bool CapNhatGiay(GiayDTO Giay)
        {
            return GiayDAL.CapNhatGiay(Giay);
        }
        public bool XoaGiay(int MaGiay)
        {
            return GiayDAL.XoaGiay(MaGiay);
        }
        public List<GiayDTO> TimGiay(string tenGiay)
        {
            return GiayDAL.TimGiay(tenGiay);
        }
    }
}
