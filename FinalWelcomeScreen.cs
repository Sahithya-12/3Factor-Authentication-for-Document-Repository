using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MultiFaceRec
{
    public partial class FinalWelcomeScreen : Form
    {
        public FinalWelcomeScreen()
        {
            InitializeComponent();
            lblUsername.Text = "Welcome " + Program.username;
            FileStream fp = new FileStream("logs.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fp);
            writer.WriteLine(DateTime.Now.ToString() + ":" + Program.username);
            writer.Close();
            fp.Close();
        }
    }
}
