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
    public partial class histogram_form : Form
    {
        private Bitmap image;
        private int count = 0;
        public histogram_form(Bitmap LoadBmp)
        {
            InitializeComponent();
            image = (Bitmap)LoadBmp.Clone();
            //this.histogram_form_Load();
        }

        private void histogram_form_Load(object sender, EventArgs e)
        {
            
        }

        public void drawHistogram()
        {
            this.Show();
            if (image != null)
            {
                if (count != 0)
                {
                    panel1.Refresh();
                }
                Histogram histogram = new Histogram(panel1, panel1.Height, panel1.Width, image);
                histogram.DrawHistogram();
                count++;
            }
        }
    }
}
