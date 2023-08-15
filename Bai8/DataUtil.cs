using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Bai8
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string fileName;

        public DataUtil()
        {
            fileName = "CongTy.xml";
            doc = new XmlDocument();
            if (!File.Exists(fileName))
            {
                root = doc.CreateElement("congty");
                doc.AppendChild(root);
                doc.Save(fileName);
            }
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public List<NhanVien> Show()
        {
            List<NhanVien> nhanVien = new List<NhanVien>();
            XmlNodeList nodeList = root.SelectNodes("nhanvien");
            foreach (XmlNode node in nodeList)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = node.Attributes["manv"].InnerText,
                    HoTen = node.SelectSingleNode("hoten").InnerText,
                    Tuoi = Convert.ToByte(node.SelectSingleNode("tuoi").InnerText),
                    Luong = Convert.ToInt32(node.SelectSingleNode("luong").InnerText),
                    Xa = node.SelectSingleNode("diachi/xa").InnerText,
                    Huyen = node.SelectSingleNode("diachi/huyen").InnerText,
                    Tinh = node.SelectSingleNode("diachi/tinh").InnerText,
                    DienThoai = node.SelectSingleNode("dienthoai").InnerText
                };
                nhanVien.Add(nv);
            }
            return nhanVien;
        }

        public void Add(NhanVien nv)
        {
            if (root.SelectSingleNode($"/congty/nhanvien[@manv='{nv.MaNV}']") == null)
            {
                XmlElement nhanvien = doc.CreateElement("nhanvien");
                XmlAttribute manv = doc.CreateAttribute("manv");
                XmlElement hoten = doc.CreateElement("hoten");
                XmlElement tuoi = doc.CreateElement("tuoi");
                XmlElement luong = doc.CreateElement("luong");
                XmlElement diachi = doc.CreateElement("diachi");
                XmlElement xa = doc.CreateElement("xa");
                XmlElement huyen = doc.CreateElement("huyen");
                XmlElement tinh = doc.CreateElement("tinh");
                XmlElement dienthoai = doc.CreateElement("dienthoai");

                manv.InnerText = nv.MaNV;
                hoten.InnerText = nv.HoTen;
                tuoi.InnerText = nv.Tuoi.ToString();
                luong.InnerText = nv.Luong.ToString();
                xa.InnerText = nv.Xa;
                huyen.InnerText = nv.Huyen;
                tinh.InnerText = nv.Tinh;
                dienthoai.InnerText = nv.DienThoai;

                nhanvien.Attributes.Append(manv);
                nhanvien.AppendChild(hoten);
                nhanvien.AppendChild(tuoi);
                nhanvien.AppendChild(luong);
                nhanvien.AppendChild(diachi);
                diachi.AppendChild(xa);
                diachi.AppendChild(huyen);
                diachi.AppendChild(tinh);
                nhanvien.AppendChild(dienthoai);
                root.AppendChild(nhanvien);
                doc.Save(fileName);
            }
        }

        public void Edit(NhanVien nv)
        {
            XmlNode node = root.SelectSingleNode($"/congty/nhanvien[@manv='{nv.MaNV}']");
            if (node != null)
            {
                node.SelectSingleNode("hoten").InnerText = nv.HoTen;
                node.SelectSingleNode("tuoi").InnerText = nv.Tuoi.ToString();
                node.SelectSingleNode("luong").InnerText = nv.Luong.ToString();
                node.SelectSingleNode("diachi/xa").InnerText = nv.Xa;
                node.SelectSingleNode("diachi/huyen").InnerText = nv.Huyen;
                node.SelectSingleNode("diachi/tinh").InnerText = nv.Tinh;
                node.SelectSingleNode("dienthoai").InnerText = nv.DienThoai;

                doc.Save(fileName);
            }
        }

        public void Delete(string maNV)
        {
            XmlNode node = root.SelectSingleNode($"/congty/nhanvien[@manv='{maNV}']");
            if (node != null)
            {
                root.RemoveChild(node);

                doc.Save(fileName);
            }
        }

        public void Find()
        {
            XmlNodeList nodeList = root.SelectNodes($"/congty/nhanvien[luong>1000]");
            int salary = 0;
            foreach (XmlNode node in nodeList)
            {
                salary += Convert.ToInt32(node.SelectSingleNode("luong").InnerText);
            }
            MessageBox.Show(nodeList.Count.ToString() + " " + salary.ToString());
        }

        public List<NhanVien> Find(string diaChi)
        {
            List<NhanVien> nhanVien = new List<NhanVien>();
            XmlNodeList nodeList = root.SelectNodes($"/congty/nhanvien/diachi[tinh='{diaChi}']");
            foreach (XmlNode node in nodeList)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = node.Attributes["manv"].InnerText,
                    HoTen = node.SelectSingleNode("hoten").InnerText,
                    Tuoi = Convert.ToByte(node.SelectSingleNode("tuoi").InnerText),
                    Luong = Convert.ToInt32(node.SelectSingleNode("luong").InnerText),
                    Xa = node.SelectSingleNode("diachi/xa").InnerText,
                    Huyen = node.SelectSingleNode("diachi/huyen").InnerText,
                    Tinh = node.SelectSingleNode("diachi/tinh").InnerText,
                    DienThoai = node.SelectSingleNode("dienthoai").InnerText
                };
                nhanVien.Add(nv);
            }
            return nhanVien;
        }
    }
}
