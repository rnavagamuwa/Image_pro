using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ImagePro
{
    class imageHandler
    {
        private Bitmap red;
        private Bitmap green;
        private Bitmap blue;
        private Bitmap BnW;

        /*This method is used to get a copy of the original image*/
        public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();

            // Return the bitmap
             return bmp;

        }

        /* This mehthod is used to extract colours*/
        public void extractClourChannels(Bitmap source)
        {
                Color c;
                int rgb;
            /*Getting 4 coppies of the original image and store them in 4 variables*/
                red = Copy(source, new Rectangle(0, 0, source.Width, source.Width));
                green = Copy(source, new Rectangle(0, 0, source.Width, source.Width));
                blue = Copy(source, new Rectangle(0, 0, source.Width, source.Width));
                BnW = Copy(source, new Rectangle(0, 0, source.Width, source.Width)); 
            /* Following two for loops are used to go throuh each pixel of the image*/
                for (int y = 0; y < source.Height; y++)
                    for (int x = 0; x < source.Width; x++)
                {
                    c = source.GetPixel(x, y); //get the pixel
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    red.SetPixel(x, y, Color.FromArgb(c.A,c.R, 0, 0));
                    green.SetPixel(x, y, Color.FromArgb(c.A, 0, c.G, 0));
                    blue.SetPixel(x, y, Color.FromArgb(c.A, 0, 0, c.B));
                    BnW.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            
        }

        //Following methods are used to get the private variables
        public Bitmap getRed()
        {
            return red;
        }
        public Bitmap getGreen()
        {
            return green;
        }
        public Bitmap getBlue()
        {
            return blue;
        }
        public Bitmap getBnW()
        {
            return BnW;
        }
      
          
       }
    
}
