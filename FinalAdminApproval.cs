using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace MultiFaceRec
{
    public partial class FinalAdminApproval : Form
    {
        Db obj;
        DateTime starttime;
        public FinalAdminApproval()
        {
            InitializeComponent();
            obj = new Db();
        }

        private void FinalAdminApproval_Load(object sender, EventArgs e)
        {
            starttime = DateTime.Now;
            obj.SendRequest(Program.username + " wanted to access strong room");
        }

        private void btnChkStatus_Click(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(starttime);
            if (span.Seconds >= 10)
            {
                if (obj.isRejected())
                {
                    SoundPlayer player = new SoundPlayer("emergency.wav");
                    player.PlaySync();
                    MessageBox.Show("Sorry !! admin did'nt approved", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        Application.OpenForms[i].Close();
                    }
                    Application.ExitThread();
                }
            }
            else
            {
                this.Hide();
                FinalWelcomeScreen frm = new FinalWelcomeScreen();
                frm.Show();
            }
        }
    }
}
