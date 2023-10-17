using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class RegisterStatus : Form
    {
        public RegisterStatus()
        {
            InitializeComponent();
            lblUser.Text = Program.username;
        }

        private void RegisterStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
