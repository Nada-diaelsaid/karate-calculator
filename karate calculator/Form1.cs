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

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            //swap players button
            if (panel3.Location == new Point(1, 0) && panel4.Location == new Point(315, 0))
            {
                panel3.Left = 315;
                panel4.Left = 1;
            }
            else if (panel4.Location == new Point(1, 0) && panel3.Location == new Point(315, 0))
            {
                panel4.Left = 315;
                panel3.Left = 1;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void lineShape5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            AKAname.Text = toolStripTextBox1.Text;
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            AOname.Text = toolStripTextBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button4, "(p)"); // + blue
            toolTip1.SetToolTip(this.button5, "(m)"); // - blue
            toolTip1.SetToolTip(this.button5, "(F1)"); // start
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.P)
            {
                button4_Click(button4, e);
                return true; // handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void sevenSegment(int n) {
            if (n == 0) {
                mid.Visible = true;
            }
            else if (n == 1)
            {
                top.Visible = true;
                mid.Visible = true;
                lefttop.Visible = true;
                leftbottom.Visible = true;
                bottom.Visible = true;
            }
        }
    }
}
