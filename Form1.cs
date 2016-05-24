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
using System.Drawing.Imaging;
using System.Collections;

namespace ImagePro
{

    public partial class Form1 : Form
    {
        private double[,] MASK;
        private static Bitmap image;   //private variables
        private Bitmap red;
        private Bitmap green;
        private Bitmap blue;
        private Bitmap BnW;
        private String path;
        public static int resizedHeight;
        public static int resizedWidth;
        OpenFileDialog imagePath = new OpenFileDialog();
        phaseTwo p2 = new phaseTwo();
        private float contrast = 1.0f;
        private float gamma = 1.0f;
        private float brightness = 1.0f;


        public Form1()
        {
            InitializeComponent();
            image = (Bitmap)pictureBox1.Image;
            imageHandler imgHndl = new imageHandler();
            imgHndl.extractClourChannels(image);
            red = imgHndl.getRed();
            blue = imgHndl.getBlue();
            green = imgHndl.getGreen();
            BnW = imgHndl.getBnW();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {



        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void greenComponent_click(object sender, EventArgs e)
        {
            pictureBox2.Image = green;
        }

        private void blueComponent_click(object sender, EventArgs e)
        {
            pictureBox2.Image = blue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Form2 frm = new Form2(image);
            //frm.Show();


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void File_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imagePath.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|JPG Image (.jpg)|*.jpg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            if (imagePath.ShowDialog() == DialogResult.OK)
            {
                image = (Bitmap)Bitmap.FromFile(imagePath.FileName);
                pictureBox1.Image = (Bitmap)image.Clone();
                pictureBox2.Image = (Bitmap)image.Clone();
                imageHandler imgHndl = new imageHandler();
                imgHndl.extractClourChannels(image); //Image is seperated into colour channels when the image is loading
                red = imgHndl.getRed();
                blue = imgHndl.getBlue();
                green = imgHndl.getGreen();
                BnW = imgHndl.getBnW();
                //listBox2.Items.Clear();
                ImageInfo info = new ImageInfo((Bitmap)image.Clone(), imagePath.FileName);
                info.Show();
                // meta();
            }



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(pictureBox1.Width);
            int height = Convert.ToInt32(pictureBox1.Height);
            Bitmap bmp = new Bitmap(width, height);
            pictureBox2.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            if (path != null)
            {
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "untitled";
            //dialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|";
            dialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|JPG Image (.jpg)|*.jpg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox1.Width);
                int height = Convert.ToInt32(pictureBox1.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox2.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName);
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = blue;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = image;
        }

        private void bnWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BnW;
        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = image;
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {


            String contrastValue = Microsoft.VisualBasic.Interaction.InputBox("The value must be between -100 to +100", "Set Contrast", "0");
            if (contrastValue.Length > 0)
            {
                pictureBox2.Image = p2.SetContrast(double.Parse(contrastValue), (Bitmap)pictureBox2.Image.Clone());
            }


        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String brightnessValue = Microsoft.VisualBasic.Interaction.InputBox("The value must be between -255 to +255", "Set Brightness", "0");
            this.brightness = float.Parse(brightnessValue) + 1.0f;
            if (brightnessValue.Length > 0)
            {
                pictureBox2.Image = p2.SetBrightness(int.Parse(brightnessValue), (Bitmap)pictureBox2.Image.Clone());
                //pictureBox2.Image = p2.gammaContrast(this.contrast, this.gamma, this.brightness, image);
            }
            //pictureBox2.Image = (Bitmap)p2.SetBrightness(100, (Bitmap)pictureBox1.Image.Clone()).Clone(); 
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pictureBox2.Image = p2.SetInvert(image);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap resizedImage = (Bitmap)pictureBox2.Image.Clone();
            int height = resizedImage.Height;
            int width = resizedImage.Width;
            String text = String.Concat(height.ToString(), ",", width.ToString());
            String resizeValue = Microsoft.VisualBasic.Interaction.InputBox("Enter values seperated by a comma:height,width", "Resizes", text);
            if (resizeValue.Length > 0)
            {
                char[] splitchar = { ',' };
                string[] words = resizeValue.Split(splitchar);
                pictureBox2.Image = p2.Resize(int.Parse(words[0]), int.Parse(words[1]), (Bitmap)pictureBox2.Image.Clone());
            }


        }



        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap resizedImage = (Bitmap)pictureBox2.Image.Clone();
            int height = resizedImage.Height;
            int width = resizedImage.Width;
            String text = String.Concat(height.ToString(), ",", width.ToString());
            String resizeValue = Microsoft.VisualBasic.Interaction.InputBox("Enter values seperated by a comma:height,width", "Resizes", text);
            if (resizeValue.Length > 0)
            {
                char[] splitchar = { ',' };
                string[] words = resizeValue.Split(splitchar);
                pictureBox2.Image = p2.Resize(int.Parse(words[0]), int.Parse(words[1]), (Bitmap)pictureBox2.Image.Clone());
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histogram_form newForm = new histogram_form((Bitmap)pictureBox2.Image.Clone());
            newForm.drawHistogram();
        }

        private void imageInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imagePath.FileName != null)
            {
                ImageInfo infoButton = new ImageInfo((Bitmap)image.Clone(), imagePath.FileName);
                infoButton.Show();
            }
        }

        private void normalizeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = p2.getNormalizedImage((Bitmap)pictureBox2.Image.Clone());
        }

        private void toolStripDropDownButton5_Click(object sender, EventArgs e)
        {

        }

        private void runLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phaseThree newPhase = new phaseThree();
            Run_Length newRun = new Run_Length(newPhase.bitPlaneRunlength((Bitmap)image.Clone()));
        }

        private void Compression_TextChanged(object sender, EventArgs e)
        {

        }


        private void loG5x5ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            phaseThree newPhase = new phaseThree();
            pictureBox2.Image = newPhase.LoG5x5((Bitmap)image.Clone());
        }

        private void loG7x7ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            phaseThree newPhase = new phaseThree();
            pictureBox2.Image = newPhase.LoG7x7((Bitmap)image.Clone());
        }

        private void custom3x3FilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            phaseThree newPhase = new phaseThree();

            customFilter cs = new customFilter();
            cs.ShowDialog();
            MASK = cs.passValue;
            if(newPhase.Conv3x3(image, MASK))
            {
                this.Invalidate();
                pictureBox2.Image = image.Clone() as Bitmap;
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void huffmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Huffman newhuff = new Huffman(BnW);

        }


    }
}
