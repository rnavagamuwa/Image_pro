using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImagePro
{
    public partial class Run_Length : Form
    {
        public Run_Length(String runlength)
        {
            InitializeComponent();         
            textBox1.Text = runlength;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "untitled";
            //dialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|";
            dialog.Filter = "Text File (*.txt)|*.txt";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.OpenFile());
          
                    writer.WriteLine(textBox1.Text);
             
                writer.Dispose();
                writer.Close();
                
            }
        }
    }
}
