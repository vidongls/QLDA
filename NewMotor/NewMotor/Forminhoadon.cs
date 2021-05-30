using DoanNET_banmayanh_.Models;
using DoanNET_banmayanh_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanNET_banmayanh_
{
    public partial class Forminhoadon : Form
    {
        public object tongtien { get; private set; }
        public Image Resource { get; private set; }
        public Forminhoadon()
        {
            InitializeComponent();
        }
        private List<tongsanpham> muasanpham = new List<tongsanpham>();

        private void bthoadonmoi_Click(object sender, EventArgs e)
        {
            string mahoadon;
            mahoadon = taomahoadon();
            txtmahoadon.Text = mahoadon;

            bthoadonmoi.Enabled = false;
            btinhoadon.Enabled = true;
            btxemtruocin.Enabled = true;

            btthoathoadon.Enabled = true;

            groupBoxitem.Enabled = true;
            txthotenkhachhang.Focus();
        }
        private string taomahoadon()
        {
            string mahoadon;

            // VN-XXXXXXXXX-XXXX
            Random ran = new Random();
            long oderpart1 = ran.Next(100000, 9999999);
            long oderpart2 = ran.Next(1000, 9999);

            mahoadon = "VN-" + oderpart1 + "-" + oderpart2;


            return mahoadon;
        }

        private void btthoathoadon_Click(object sender, EventArgs e)
        {
            bthoadonmoi.Enabled = true;
            btinhoadon.Enabled = false;
            btxemtruocin.Enabled = false;

            btthoathoadon.Enabled = false;

            groupBoxitem.Enabled = false;

            txthotenkhachhang.Clear();
            comboboxsanpham.SelectedIndex = -1;
            txtsoluong.Clear();
            txtgia.Clear();
            txtmahoadon.Clear();

            txttonggiatien.Text = "0";
            txtthuevat.Text = "0";
            txttongtienthanhtoan.Text = "0";

            dgrsanpham.DataSource = null;
            muasanpham.Clear();
        }

        private void bttinhtien_Click(object sender, EventArgs e)
        {
            if (checkxacthuc())
            {
                tongsanpham item = new tongsanpham()
                {
                    sanpham = comboboxsanpham.Text,
                    soluong = Convert.ToInt16(txtsoluong.Text.Trim()),
                    gia = Convert.ToDecimal(txtgia.Text.Trim()),
                    tongtien = Convert.ToInt16(txtsoluong.Text.Trim()) * Convert.ToDecimal(txtgia.Text.Trim())

                };

                muasanpham.Add(item);

                dgrsanpham.DataSource = null;
                dgrsanpham.DataSource = muasanpham;

                //tinhtonggiatien
                decimal tonggiatien = muasanpham.Sum(x => x.tongtien);
                txttonggiatien.Text = tonggiatien.ToString();

                //tinhtienthue
                decimal thue = (10 * tonggiatien) / 100;
                txtthuevat.Text = thue.ToString();

                //tongtienthanhtoan
                decimal tongtienthanhtoan = tonggiatien + thue;
                txttongtienthanhtoan.Text = tongtienthanhtoan.ToString();




                comboboxsanpham.SelectedIndex = -1;
                txtsoluong.Clear();
                txtgia.Clear();
            }
        }
        public bool checkxacthuc()
        {
            if (txthotenkhachhang.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Chưa Nhập Tên !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txthotenkhachhang.Focus();
                return false;
            }
            if (comboboxsanpham.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn sản phẩm!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtsoluong.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Chưa nhập số lượng!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return false;
            }
            else
            {
                int soluongsanpham;
                bool nhapsoluong = int.TryParse(txtsoluong.Text.Trim(), out soluongsanpham);

                if (!nhapsoluong)
                {
                    MessageBox.Show("Bạn phải nhập số lượng !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsoluong.Clear();
                    txtsoluong.Focus();
                    return false;
                }
            }
            if (txtgia.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Chưa nhập giá tiền!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgia.Focus();
                return false;
            }
            else
            {
                decimal gia;
                bool isgia = decimal.TryParse(txtgia.Text.Trim(), out gia);

                if (!isgia)
                {
                    MessageBox.Show("Bạn phải nhập giá tiền !", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtgia.Clear();
                    txtgia.Focus();
                    return false;
                }
            }
            return true;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dgrsanpham.CurrentCell.RowIndex;

            muasanpham.RemoveAt(index);

            dgrsanpham.DataSource = null;
            dgrsanpham.DataSource = muasanpham;

            //tinhtonggiatien
            decimal tonggiatien = muasanpham.Sum(x => x.tongtien);
            txttonggiatien.Text = tonggiatien.ToString();

            //tinhtienthue
            decimal thue = (10 * tonggiatien) / 100;
            txtthuevat.Text = thue.ToString();

            //tongtienthanhtoan
            decimal tongtienthanhtoan = tonggiatien + thue;
            txttongtienthanhtoan.Text = tongtienthanhtoan.ToString();
        }

        private void dgrsanpham_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dgrsanpham.HitTest(e.X, e.Y);
                dgrsanpham.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(dgrsanpham, e.X, e.Y);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.banner;

            e.Graphics.DrawImage(image, 210, 0, image.Width, image.Height);

            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 220));

            e.Graphics.DrawString("Mã hóa đơn: " + txtmahoadon.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));

            e.Graphics.DrawString("Họ tên khách hàng: " + txthotenkhachhang.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 263));

            e.Graphics.DrawString
                ("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 270));

            e.Graphics.DrawString("Tên sản phẩm", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 295));

            e.Graphics.DrawString("Số lượng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 295));

            e.Graphics.DrawString("Giá Tiền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 295));

            e.Graphics.DrawString("Tổng tiền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 295));

            e.Graphics.DrawString
                ("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 305));

            int yPos = 335;

            foreach (var i in muasanpham)
            {
                e.Graphics.DrawString(i.sanpham, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));

                e.Graphics.DrawString(i.soluong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(330, yPos));

                e.Graphics.DrawString(i.gia.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, yPos));

                e.Graphics.DrawString(i.tongtien.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(710, yPos));

                yPos += 30;
            }
            e.Graphics.DrawString
               ("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos - 10));

            e.Graphics.DrawString("Tổng tiền (VNĐ): " + txttonggiatien.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(540, yPos + 30));

            e.Graphics.DrawString("Thuế VAT (10%): " + txtthuevat.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(540, yPos + 60));

            e.Graphics.DrawString("Tổng tiền thanh toán (VNĐ): " + txttongtienthanhtoan.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(540, yPos + 90));

            e.Graphics.DrawString("Nhân viên bán hàng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos + 150));

            Image chuky = Resources.chuky1;

            e.Graphics.DrawImage(chuky, 620, 550, chuky.Width, chuky.Height);
        }

        private void btxemtruocin_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btinhoadon_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }
    }
