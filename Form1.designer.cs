namespace MultiFaceRec
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.picReset = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).BeginInit();
            this.SuspendLayout();
            // 
            // TPanel
            // 
            this.TPanel.AutoSize = true;
            this.TPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.TPanel.ColumnCount = 3;
            this.TPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.49505F));
            this.TPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.50495F));
            this.TPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.TPanel.Location = new System.Drawing.Point(15, 111);
            this.TPanel.Name = "TPanel";
            this.TPanel.RowCount = 3;
            this.TPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.TPanel.Size = new System.Drawing.Size(385, 216);
            this.TPanel.TabIndex = 0;
            this.TPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tableLayoutPanel1_ControlAdded);
            this.TPanel.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            this.TPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TPanel_MouseDoubleClick);
            // 
            // BtnImages
            // 
            this.BtnImages.Location = new System.Drawing.Point(290, 344);
            this.BtnImages.Name = "BtnImages";
            this.BtnImages.Size = new System.Drawing.Size(109, 45);
            this.BtnImages.TabIndex = 1;
            this.BtnImages.Text = "Register Images";
            this.BtnImages.UseVisualStyleBackColor = true;
            this.BtnImages.Click += new System.EventHandler(this.BtnImages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.Location = new System.Drawing.Point(18, 38);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(381, 26);
            this.TxtUsername.TabIndex = 3;
            // 
            // picReset
            // 
            this.picReset.Image = ((System.Drawing.Image)(resources.GetObject("picReset.Image")));
            this.picReset.Location = new System.Drawing.Point(18, 333);
            this.picReset.Name = "picReset";
            this.picReset.Size = new System.Drawing.Size(34, 34);
            this.picReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReset.TabIndex = 4;
            this.picReset.TabStop = false;
            this.picReset.Click += new System.EventHandler(this.picReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reset";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 405);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picReset);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnImages);
            this.Controls.Add(this.TPanel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registeration";
          
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TPanel;
        private System.Windows.Forms.Button BtnImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.PictureBox picReset;
        private System.Windows.Forms.Label label2;
    }
}

