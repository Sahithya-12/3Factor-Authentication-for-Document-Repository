using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MultiFaceRec
{
    public partial class Form1 : Form
    {
        ArrayList ImgList = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
         
        }

        private void BtnImages_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text.Length == 0)
                MessageBox.Show("Please choose username to register", "Image authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (File.Exists(TxtUsername.Text))
            {
                DialogResult res = MessageBox.Show("Username exists , do you want to overwrite ?", "Image authentication", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else if (ImgList.Count < 3)
            {
                MessageBox.Show("Please choose 3 different images", "Image authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FileStream stream = new FileStream(TxtUsername.Text+".txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < ImgList.Count; i++)
            {
                writer.WriteLine(ImgList[i] + " ");
            }
            writer.Close();
            stream.Close();
            this.Hide();
            Program.mode = 1;
            Program.username = TxtUsername.Text;
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
        }

        private void TPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = 0;
            int verticalOffset = 0;
            foreach (int h in TPanel.GetRowHeights())
            {
                int column = 0;
                int horizontalOffset = 0;
                foreach (int w in TPanel.GetColumnWidths())
                {
                    Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                    if (rectangle.Contains(e.Location))
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && ImgList.Count <= 2)
                        {
                            PictureBox pic = new PictureBox();
                            pic.Image = Image.FromFile(dialog.FileName);
                            ImgList.Add(Path.GetFileName(dialog.FileName));
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Dock = DockStyle.Fill;
                            //MessageBox.Show(row + "," + column);
                            TPanel.Controls.Add(pic, column, row);
                        }
                        else
                        {
                            MessageBox.Show("You have selected all 3 images , plz reset and choose again", "Image authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    horizontalOffset += w;
                    column++;
                }
                verticalOffset += h;
                row++;
            }

        }

        private void picReset_Click(object sender, EventArgs e)
        {
            ImgList.Clear();
            TPanel.Controls.Clear();
        }
 

    }
}
