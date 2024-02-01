using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
namespace DAL
{
    public class GiayDAL
    {

        public List<GiayDTO> LayDanhSachGiay()
        {
            List<GiayDTO> dsGiay = new List<GiayDTO>();
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM GIAY", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GiayDTO giayDTO = new GiayDTO();
                    giayDTO.MaGiay = reader.GetInt32(0);
                    giayDTO.TenGiay = reader.GetString(1);
                    giayDTO.Size = reader.GetInt32(2);
                    giayDTO.Gia = reader.GetInt32(3);
                    giayDTO.MaNCC = reader.GetInt32(4);
                    giayDTO.Hinh = reader.GetString(5);
                    giayDTO.MaLoai = reader.GetInt32(6);
                    giayDTO.TrangThai = reader.GetInt32(7);
                    dsGiay.Add(giayDTO);
                }
                reader.Close();
            }
            return dsGiay;
        }

    }
}
