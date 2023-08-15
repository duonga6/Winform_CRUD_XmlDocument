using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai8
{
    public partial class Bai8 : Form
    {
        private DataUtil data = new DataUtil();
        private List<NhanVien> nhanvien = new List<NhanVien>();

        public Bai8()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            nhanvien.Clear();
            nhanvien = data.Show();
            dgvNhanVien.DataSource = nhanvien;
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            data.Add(new NhanVien() { MaNV = txtMaNV.Text, HoTen = txtHoTen.Text, Tuoi = Convert.ToByte(txtTuoi.Text), Luong = Convert.ToInt32(txtLuong.Text), Xa = txtXa.Text, Huyen = txtHuyen.Text, Tinh = txtTinh.Text, DienThoai = txtDienThoai.Text });
            LoadData();
        }

        private void Bai8_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvNhanVien.CurrentRow;

            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtTuoi.Text = row.Cells["Tuoi"].Value?.ToString();
            txtLuong.Text = row.Cells["Luong"].Value?.ToString();
            txtXa.Text = row.Cells["Xa"].Value?.ToString();
            txtHuyen.Text = row.Cells["Huyen"].Value?.ToString();
            txtTinh.Text = row.Cells["Tinh"].Value?.ToString();
            txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            data.Edit(new NhanVien() { MaNV = txtMaNV.Text, HoTen = txtHoTen.Text, Tuoi = Convert.ToByte(txtTuoi.Text), Luong = Convert.ToInt32(txtLuong.Text), Xa = txtXa.Text, Huyen = txtHuyen.Text, Tinh = txtTinh.Text, DienThoai = txtDienThoai.Text });
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                data.Delete(txtMaNV.Text);
                LoadData();
            }    
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            data.Find();
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
