using NewMotor.Connect;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace NewMotor
{
    public partial class ThongKe : Form
    {
        private static int index;
       
        public ThongKe()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);

        private void btnhienthi_Click(object sender, EventArgs e)
        {
           
        }
             
        private void grvthongke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void grvthongke_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
           
        }
      
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
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
