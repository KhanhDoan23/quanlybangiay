using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmBanGiay : Form
    {
        private GiayBUS GiayBUS;
        public frmBanGiay()
        {
            InitializeComponent();
            GiayBUS = new GiayBUS();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmBanGiay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cuahang_bangiayDataSet1.Giay' table. You can move, or remove it, as needed.
            this.giayTableAdapter.Fill(this.cuahang_bangiayDataSet1.Giay);
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            dgvBanGiay.DataSource = GiayBUS.LayDanhSachGiay();
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // Thiết lập các thuộc tính cho dialog chọn file ảnh
            dialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            dialog.Title = "Chọn ảnh";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file ảnh được chọn
                string filePath = dialog.FileName;
                // Hiển thị ảnh lên PictureBox
                ptB_giay.Image = new Bitmap(filePath);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(ptB_giay.Image != null)
            {
                ptB_giay.Image = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GiayDTO Giay = new GiayDTO();
            Giay.MaGiay = int.Parse(txtMaGiay.Text);
            Giay.TenGiay = txtTenGiay.Text;
            Giay.Size =int.Parse(txtSize.Text);
            Giay.Gia = int.Parse(txt_Gia.Text);
            Giay.MaNCC = int.Parse(txtMancc.Text);
            Giay.Hinh = txtHinh.Text;
            Giay.MaLoai =int.Parse(txtMaLoai.Text);
            Giay.TrangThai = cboTrangThai.SelectedIndex;

            if (GiayBUS.ThemGiay(Giay))
            {
                MessageBox.Show("Thêm giày thành công");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm giày thất bại");
            }
        }

        private void dgvBanGiay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBanGiay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                int trangThai = (int)e.Value;
                if (trangThai == 1)
                {
                    e.Value = "Hoạt động";
                }
                else if (trangThai == 0)
                {
                    e.Value = "Không hoạt động";
                }
            }
        }

        private void dgvBanGiay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBanGiay.Rows[e.RowIndex];
                txtMaGiay.Text = row.Cells["MaGiay"].Value.ToString();
                txtTenGiay.Text = row.Cells["TenGiay"].Value.ToString();
                txtSize.Text = row.Cells["Size"].Value.ToString();
                txt_Gia.Text = row.Cells["Gia"].Value.ToString();
                txtMancc.Text = row.Cells["MaNCC"].Value.ToString();
                txtHinh.Text = row.Cells["Hinh"].Value.ToString();
                txtMaLoai.Text = row.Cells["MaLoai"].Value.ToString();
                cboTrangThai.Text = (row.Cells["TrangThai"].Value.ToString() == "1") ? "Hoạt động" : "Không hoạt động";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            GiayDTO Giay = new GiayDTO();
            Giay.MaGiay = int.Parse(txtMaGiay.Text);
            Giay.TenGiay = txtTenGiay.Text;
            Giay.Size = int.Parse(txtSize.Text);
            Giay.Gia = int.Parse(txt_Gia.Text);
            Giay.MaNCC = int.Parse(txtMancc.Text);
            Giay.Hinh = txtHinh.Text;
            Giay.MaLoai = int.Parse(txtMaLoai.Text);
            Giay.TrangThai = cboTrangThai.SelectedIndex;

            if (GiayBUS.CapNhatGiay(Giay))
            {
                MessageBox.Show("Cập nhật giày thành công");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Cập nhật giày thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaGiay = int.Parse(txtMaGiay.Text);

            if (GiayBUS.XoaGiay(MaGiay))
            {
                MessageBox.Show("Xóa Giày thành công");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Xóa Giày thất bại");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenGiay = txtTim.Text;
            dgvBanGiay.DataSource = GiayBUS.TimGiay(tenGiay);
        }
    }
}
