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
    public partial class OtpVerfication : Form
    {
        private string otp;
        public OtpVerfication()
        {
            InitializeComponent();
        }

        private void OtpVerfication_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            otp = rnd.Next(1000, 9999).ToString();
            RapidMailSender.Send(Program.username, otp);
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (TxtOTP.Text == otp)
            {
                Program.otpverification = true;
                FinalAdminApproval frm = new FinalAdminApproval();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Sorry !!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.otpverification = false;
            }
        }
    }
}
