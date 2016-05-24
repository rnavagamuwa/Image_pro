using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class resize : Form
    {
        public resize(int height, int width)
        {
            InitializeComponent();
            width_text.Text = width.ToString();
            height_text.Text = height.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Okay_Click(object sender, EventArgs e)
        {
            Form1.resizedHeight = int.Parse(height_text.Text);
            Form1.resizedWidth = int.Parse(width_text.Text);
            Form1 frm = new Form1();
            this.Close();
        }

    }
}
