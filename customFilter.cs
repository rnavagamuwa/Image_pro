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
    public partial class customFilter : Form
    {
        public double[,] passValue;
        public customFilter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            passValue = new double[3, 3] {
                                {Double.Parse(textBox1.Text),Double.Parse(textBox2.Text),Double.Parse(textBox3.Text)},
                                {Double.Parse(textBox4.Text),Double.Parse(textBox5.Text),Double.Parse(textBox6.Text)},
                                {Double.Parse(textBox7.Text),Double.Parse(textBox8.Text),Double.Parse(textBox9.Text)},

                            };

            this.Close();
        }

        private void customFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
