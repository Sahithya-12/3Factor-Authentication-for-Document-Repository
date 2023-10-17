using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class AdminForRegister : Form
    {
        public AdminForRegister()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "admin@123")
            {
                Program.mode = 1;
                Form1 frm = new Form1();
                frm.Show();
            }
        }
    }
}
