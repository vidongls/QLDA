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

    public partial class Form1 : Form
    {
        
        public Form1(string id)
        {

            InitializeComponent();
            if(id == "0")
            {
                //admin
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formmainmenu fr = new Formmainmenu();
           
        }
    }
}
