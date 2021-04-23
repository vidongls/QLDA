using NewMotor.Connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace NewMotor
{
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
       

        private void btntinhtien_Click(object sender, EventArgs e)
        {

        }

        private void txtTongtien_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
          
        }
        public static int role;
        private void btnthem_Click(object sender, EventArgs e)
        {
        }
      
        private void btnsua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
   
           
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    
        private void grvPhieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
        }
        private void btnexcel_Click(object sender, EventArgs e)
        {
           
        }
    }
}
