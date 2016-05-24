using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImagePro
{
    class phaseTwo
    {
        public Bitmap SetContrast(double contrast, Bitmap _currentBitmap)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            return _currentBitmap;
        }

        public Bitmap SetBrightness(int brightness, Bitmap _currentBitmap)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, System.Drawing.Color.FromArgb(255, (byte)cR, (byte)cG, (byte)cB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            return _currentBitmap;
        }

        public Bitmap SetInvert(Bitmap _currentBitmap)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    //bmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            return _currentBitmap;
        }

        public Bitmap Resize(int newWidth, int newHeight, Bitmap _currentBitmap)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb
                (255, nRed, nGreen, nBlue));
                    }
                }
                _currentBitmap = (Bitmap)bmap.Clone();
                return _currentBitmap;
            }
            return _currentBitmap;
        }
        public Bitmap gammaContrast(float contrast, float gamma, float brightness, Bitmap img)
        {
            Bitmap img2;
            img2 = img.Clone() as Bitmap;
            Bitmap adjustedImage = img2.Clone() as Bitmap;



            // create matrix that will brighten and contrast the image
            float[][] colorMatrix ={
                new float[] {contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new float[] {brightness-1.0f, brightness-1.0f, brightness-1.0f, 0, 1}};

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(colorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(img2, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, img2.Width, img2.Height,
                GraphicsUnit.Pixel, imageAttributes);
            return adjustedImage.Clone() as Bitmap;
        }

        public Bitmap getNormalizedImage(Bitmap img)
        {
            float max = 1;
            float min = 0;
            float currentPix;
            Bitmap imageLoaded;
            Color pixelColor;
            float normalizedColor;
            Color normalized;
            float percentage;
            imageLoaded = img.Clone() as Bitmap;
            for (int x = 0; x < imageLoaded.Height; x++)
            {
                for (int y = 0; y < imageLoaded.Width; y++)
                {
                    float pixelBrightness = imageLoaded.GetPixel(x, y).GetBrightness();
                    min = Math.Min(min, pixelBrightness);
                    max = Math.Max(max, pixelBrightness);
                }
            }
            for (int x=0; x<imageLoaded.Height; x++)
            {
                for(int y=0; y<imageLoaded.Width; y++)
                {
                    pixelColor = imageLoaded.GetPixel(x, y);
                    normalizedColor = ((pixelColor.GetBrightness() - min) - (max - min)) * 255;
                    percentage = normalizedColor * (float)0.01;
                    //normalized = ColorConverter.ColorFromAhsb(pixelColor.A, pixelColor.GetHue(),pixelColor.GetSaturation(), normalizedColor);
                    imageLoaded.SetPixel(x, y, Color.FromArgb(pixelColor.A, pixelColor.R*(byte)percentage, pixelColor.G* (byte)percentage, pixelColor.B* (byte)percentage));
                }
            }
            return imageLoaded;
        }
         
        }
    }


    

