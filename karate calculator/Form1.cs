using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace karate_calculator
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;

        public Form1()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.digital_7;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.digital_7.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.digital_7.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 48.0F);
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
            redScore.Font =myFont;
            blueScore.Font = myFont;
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button4, "(P)"); // + blue
            toolTip1.SetToolTip(this.button5, "(M)"); // - blue
            toolTip1.SetToolTip(this.button13, "(SHIFT+P)"); // + red
            toolTip1.SetToolTip(this.button12, "(SHIFT+M)"); // - red
            toolTip1.SetToolTip(this.button1, "(F1)"); // start
            toolTip1.SetToolTip(this.button14, "(SHIFT+F1)"); // reset
            toolTip1.SetToolTip(this.yukoB, "(Y)"); // yuko blue button
            toolTip1.SetToolTip(this.yukoR, "(SHIFT+Y)"); // yuko red button
            toolTip1.SetToolTip(this.wazariB, "(W)"); // wazari blue button
            toolTip1.SetToolTip(this.wazariR, "(SHIFT+W)"); // wazari red button
            toolTip1.SetToolTip(this.ipponB, "(I)"); // ippon blue button
            toolTip1.SetToolTip(this.ipponR, "(SHIFT+I)"); // ippon red button

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.P)
            {
                button4_Click(button4, e);
                return true; // handled
            }
            else if (e.Shift )
            {
                button13_Click(button4, e);
                return true; // handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e) /// + blue button
        {
            
            int temp;
            temp = Int32.Parse(blueScore.Text);
            temp++;
            /////format string in 00 form
            string s;
            s = string.Format("{0:00}", temp);
            blueScore.Text = s;
            
        }

        private void button5_Click(object sender, EventArgs e) // - blue button
        {
            int temp;
            temp = Int32.Parse(blueScore.Text);
            if (temp <= 0) { }//make sure number doesnot get below zero
            else
            {
                temp--;
                /////format string in 00 form
                string s;
                s = string.Format("{0:00}", temp);
                blueScore.Text = s;
            }
        }

        private void button13_Click(object sender, EventArgs e) // + red button
        {
            int temp;
            temp = Int32.Parse(redScore.Text);
            temp++;
            /////format string in 00 form
            string s;
            s = string.Format("{0:00}", temp);
            redScore.Text = s;
        }

        private void button12_Click(object sender, EventArgs e) // - red button
        {
            int temp;
            temp = Int32.Parse(redScore.Text);
            if (temp <= 0) { } //make sure number doesnot get below zero
            else
            {
                temp--;
                /////format string in 00 form
                string s;
                s = string.Format("{0:00}", temp);
                redScore.Text = s;
            }
        }
       
    }
}
