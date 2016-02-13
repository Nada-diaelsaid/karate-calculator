using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace karate_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////helo there
            ///commit?
            ///
        }

        private void addPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (openFileDialog1)
            {
                openFileDialog1.Title = "Open Image";
                openFileDialog1.Filter = "Images (*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    // Add the new control to its parent's controls collection
                    //this.Controls.Add(PictureBox1);
                }
            }
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
        }
    }
}
