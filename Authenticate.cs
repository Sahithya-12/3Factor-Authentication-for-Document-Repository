using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Media;
namespace MultiFaceRec
{
    public partial class Authenticate : Form
    {
        ArrayList ImgList = new ArrayList();
        ArrayList LoginList = new ArrayList();
        public TableLayoutPanel tableLayoutPanel { get; set; }
        public Authenticate()
        {
            InitializeComponent();
        }

        public void clickOnSpace(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            string filename = (string)pic.Tag;
            LoginList.Add(filename.Trim());
            lblPassword.Text = "";
            for (int i = 1; i <= LoginList.Count; i++)
                lblPassword.Text += "*";
        }

        private void LoadImages()
        {
            if (TxtUsername.Text.Length == 0)
            {
                MessageBox.Show("Please input username to proceed", "Photo authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Random rnd = new Random();
            string[] names = Directory.GetFiles("images");

            string[] userimage = System.IO.File.ReadAllLines(TxtUsername.Text+".txt");
            string[] StrImglist = new string[9];
            ArrayList ImgList = new ArrayList();

            int success = 0;
            while (success <= 2)
            {
                int ndx = rnd.Next(9);
                if (StrImglist[ndx] == null)
                {
                    StrImglist[ndx] = "images\\" + userimage[success];
                    ImgList.Add(StrImglist[ndx].Trim());
                    success++;
                }
            }

            while (success <= 8)
            {
                int ndx = rnd.Next(names.Length);
                if (ImgList.Contains(names[ndx]) == false)
                {
                    for (int i = 0; i <= 8; i++)
                    {
                        if (StrImglist[i] == null)
                        {
                            ImgList.Add(names[ndx]);
                            StrImglist[i] = names[ndx];
                            success++;
                            break;
                        }
                    }
                }
            }

            int imgndx = 0;
            for (int row = 0; row <= 2; row++)
            {
                for (int col = 0; col <= 2; col++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Dock = DockStyle.Fill;
                    string path = Application.StartupPath + "\\" + StrImglist[imgndx++];
                    pic.Image = Image.FromFile(path);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.MouseClick += new MouseEventHandler(clickOnSpace);
                    pic.Tag = Path.GetFileName(path);
                    TPanel.Controls.Add(pic);
                }
            }
        }

        private void Authenticate_Load(object sender, EventArgs e)
        {

          
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(TxtUsername.Text+".txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            ArrayList compareList = new ArrayList();
            string sequence = null;
            while ((sequence = reader.ReadLine()) != null)
            {
                compareList.Add(sequence.Trim());
            }
            if (CompareArrayLists(compareList, LoginList))
            {
                Program.username = TxtUsername.Text;
                Program.mode = 2;
                MessageBox.Show("Authentication granted", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();
            }
            else
            {
                SoundPlayer soundPlayer= new SoundPlayer("emergencyy.wav");
                SoundPlayer player = soundPlayer;
                player.PlaySync();
                MessageBox.Show("Authentication failed , selection resetted ", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImgList.Clear();
            }
            reader.Close();
            stream.Close();
        }

        private bool CompareArrayLists(ArrayList arr1, ArrayList arr2)
        {
            //Check if the two arraysLists have the same length
            if (arr1.Count != arr2.Count)
                return false;


            for (int i = 0; i < arr1.Count; i++)
            {
               // MessageBox.Show(arr1[i] + "," + arr2[i]);
                if (arr1[i].ToString()!=arr2[i].ToString())
                    return false;
            }

            return true;
        }

        private void BtnLoadImages_Click(object sender, EventArgs e)
        {
            LoadImages();
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            lblPassword.Text = "";
            TPanel.Controls.Clear();
            ImgList.Clear();
            LoginList.Clear();
        }

    }
}
