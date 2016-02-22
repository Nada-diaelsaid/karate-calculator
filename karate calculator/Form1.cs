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
                blueScore.Text = temp.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e) // - blue button
        {
            int temp;
            temp = Int32.Parse(blueScore.Text);
            if (temp <= 0) { }
            else
            {
                temp--;
                blueScore.Text = temp.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e) // + red button
        {
            int temp;
            temp = Int32.Parse(redScore.Text);
            temp++;
            temp.ToString("D2");

            redScore.Text = temp.ToString();
        }

        private void button12_Click(object sender, EventArgs e) // - red button
        {
            int temp;
            temp = Int32.Parse(redScore.Text);
            if (temp <= 0) { }
            else
            {
                temp--;
                temp.ToString("00");
                redScore.Text = temp.ToString();
            }
        }
        //private void sevenSegment(int n,int id) {
        //    if (id == 0)
        //    {
        //         if (n == 0)
        //        {
        //            top.Visible = true;
        //            mid.Visible = false;
        //            bottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = true;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //        }
        //        else if (n == 1)
        //        {
        //            top.Visible = false;
        //            mid.Visible = false;
        //            bottom.Visible = false;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = false;
        //            leftbottom.Visible = false;
        //        }
        //        else if (n == 2)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = true;
        //            rightbottom.Visible = false;
        //            lefttop.Visible = false;
        //            leftbottom.Visible = true;
        //        }
        //        else if (n == 3)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = false;
        //            leftbottom.Visible = false;
        //        }
        //        else if (n == 4)
        //        {
        //            top.Visible = false;
        //            mid.Visible = true;
        //            bottom.Visible = false;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = false;
        //        }
        //        else if (n == 5)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = false;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = false;
        //        }
        //        else if (n == 6)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = false;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = true;
        //        }
        //        else if (n == 7)
        //        {
        //            top.Visible = true;
        //            mid.Visible = false;
        //            bottom.Visible = false;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = false;
        //            leftbottom.Visible = false;
        //        }
        //        else if (n == 8)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = true;
        //        }
        //        else if (n == 9)
        //        {
        //            top.Visible = true;
        //            mid.Visible = true;
        //            bottom.Visible = true;
        //            righttop.Visible = true;
        //            rightbottom.Visible = true;
        //            lefttop.Visible = true;
        //            leftbottom.Visible = false;
        //        }
        //    }
            
        //    else if (id == 1) {
        //        if (n == 0)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = false;
        //            bottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = true;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //        }
        //        else if (n == 1)
        //        {
        //            top1.Visible = false;
        //            mid1.Visible = false;
        //            bottom1.Visible = false;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = false;
        //            leftbottom1.Visible = false;
        //        }
        //        else if (n == 2)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = false;
        //            lefttop1.Visible = false;
        //            leftbottom1.Visible = true;
        //        }
        //        else if (n == 3)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = false;
        //            leftbottom1.Visible = false;
        //        }
        //        else if (n == 4)
        //        {
        //            top1.Visible = false;
        //            mid1.Visible = true;
        //            bottom1.Visible = false;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = false;
        //        }
        //        else if (n == 5)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = false;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = false;
        //        }
        //        else if (n == 6)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = false;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = true;
        //        }
        //        else if (n == 7)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = false;
        //            bottom1.Visible = false;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = false;
        //            leftbottom1.Visible = false;
        //        }
        //        else if (n == 8)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = true;
        //        }
        //        else if (n == 9)
        //        {
        //            top1.Visible = true;
        //            mid1.Visible = true;
        //            bottom1.Visible = true;
        //            righttop1.Visible = true;
        //            rightbottom1.Visible = true;
        //            lefttop1.Visible = true;
        //            leftbottom1.Visible = false;
        //        }
        //    }
        //}

        //private void calculateScore(string color) {
        //  if (color == "blue"){
        //        int score = Int32.Parse(blueScore.Text);
        //        if (score <= 9)
        //        {
        //            sevenSegment(score, 0);
        //        }
        //        else
        //        {
        //            int[] d = getDigits(score);
        //            sevenSegment(d[0], 0);
        //            sevenSegment(d[1], 1);
        //        }
        //    }
        //}
        //private int[] getDigits(int num)
        //{
        //    List<int> listOfInts = new List<int>();
        //    while (num > 0)
        //    {
        //        listOfInts.Add(num % 10);
        //        num = num / 10;
        //    }
        //    listOfInts.Reverse();
        //    return listOfInts.ToArray();
        //}
    }
}
