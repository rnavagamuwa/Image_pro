using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace ImagePro
{
    partial class phaseThree
    {

        SaveFileDialog savePath = new SaveFileDialog();
        public String runLenth(Bitmap image)
        {
            Bitmap imageLoaded = image.Clone() as Bitmap;
            int intensity;
            String binary;
            String runLength = "";
            int arraySize = image.Height * image.Width;
            char[] b = new char[arraySize];
            for (int x = 0; x < imageLoaded.Height; x++)
            {
                for (int y = 0; y < imageLoaded.Width; y++)
                {
                    //intensity = Convert.ToInt32(image.GetPixel(x, y).GetBrightness());
                    // binary = Convert.ToString(intensity, 2).PadLeft(arraySize, '0');
                    binary = "11111111111111111111000000000000000001111000";
                    binary = binary.PadLeft(255, '0');
                    b = binary.ToCharArray();
                    int i = 0;
                    int count = 0;
                    char temp = b[0];
                    int firstTime = 1;
                    while (i < arraySize)
                    {

                        if (temp == b[i])
                            count++;
                        else
                        {
                            if (firstTime == 1)
                            {
                                runLength += temp.ToString() + "," + count.ToString();
                                firstTime = 0;
                                temp = b[i];
                                count = 1;
                            }
                            else
                                runLength += "," + count.ToString();
                            temp = b[i];
                            count = 1;
                        }


                        i++;
                    }
                    if (firstTime == 1)
                    {
                        runLength += temp.ToString() + "," + count.ToString() + ",";
                        firstTime = 0;
                    }
                    else
                        runLength += "," + count.ToString() + ",";


                }
            }
            return runLength;
        }

        public String bitPlaneRunlength(Bitmap image)
        {
            String p0 = "";
            String p1 = "";
            String p2 = "";
            String p3 = "";
            String p4 = "";
            String p5 = "";
            String p6 = "";
            String p7 = "";
            int pixelvalue;
            String bin = "";
            char[] bitArray = new char[8];
            int i;
            Color c;
            Bitmap loadedImage = image.Clone() as Bitmap;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    bin = "";
                    c = loadedImage.GetPixel(x, y);
                    pixelvalue = (int)((c.R + c.G + c.B) / 3);
                    //float pix = image.GetPixel(x, y).GetBrightness();
                    //bin = loadedImage.GetPixel(x, y).GetBrightness().ToString().PadLeft(8,'0');
                    bin = Convert.ToString(pixelvalue, 2).PadLeft(8, '0');
                    //bin = "11100111";
                    bitArray = bin.ToArray();
                    i = 0;
                    while (i < 8)
                    {
                        if (i == 0)
                            p0 = p0 + bitArray[i];
                        if (i == 1)
                            p1 = p1 + bitArray[i];
                        if (i == 2)
                            p2 = p2 + bitArray[i];
                        if (i == 3)
                            p3 = p3 + bitArray[i];
                        if (i == 4)
                            p4 = p4 + bitArray[i];
                        if (i == 5)
                            p5 = p5 + bitArray[i];
                        if (i == 6)
                            p6 = p6 + bitArray[i];
                        if (i == 7)
                            p7 = p7 + bitArray[i];

                        i++;
                    }

                }
            }
            int arraySize = image.Height * image.Width;
            char[] b = new char[arraySize];
            String runLenth = "";
            b = p0.ToCharArray();
            int j = 0;
            int count = 0;
            char temp = b[0];
            int firstTime = 1;
            runLenth = "PLane 0: ";
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";

            runLenth = runLenth + "\r\n" + "PLane 1: ";
            b = p1.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 2: ";
            b = p2.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 3: ";
            b = p3.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 4: ";
            b = p4.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 5: ";
            b = p5.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 6: ";
            b = p6.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            runLenth = runLenth + "\r\n" + "PLane 7: ";
            b = p7.ToCharArray();
            j = 0;
            count = 0;
            temp = b[0];
            firstTime = 1;
            while (j < arraySize)
            {

                if (temp == b[j])
                    count++;
                else
                {
                    if (firstTime == 1)
                    {
                        runLenth += temp.ToString() + "," + count.ToString();
                        firstTime = 0;
                        temp = b[j];
                        count = 1;
                    }
                    else
                        runLenth += "," + count.ToString();
                    temp = b[j];
                    count = 1;
                }


                j++;
            }
            if (firstTime == 1)
            {
                runLenth += temp.ToString() + "," + count.ToString() + ",";
                firstTime = 0;
            }
            else
                runLenth += "," + count.ToString() + ",";
            return runLenth;
        }
        public Bitmap LoG5x5(Bitmap SrcImage)
        {
            double[,] MASK = new double[5, 5] {
                                {0,0,1,0,0},
                                {0,1,2,1,0},
                                {1,2,-16,2,1},
                                {0,1,2,1,0},
                                {0,0,1,0,0},

                            };

            double nTemp = 0.0;
            double c = 0;

            int mdl, size;
            size = 5;
            mdl = size / 2;

            double min, max;
            min = max = 0.0;

            double sum = 0.0;
            double mean;
            double d = 0.0;
            double s = 0.0;
            int n = 0;

            Bitmap bitmap = new Bitmap(SrcImage.Width + mdl, SrcImage.Height + mdl);
            int l, k;

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData srcData = SrcImage.LockBits(new Rectangle(0, 0, SrcImage.Width, SrcImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                int offset = 3;

                for (int colm = 0; colm < srcData.Height - size; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = 0; row < srcData.Width - size; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        sum += nTemp;
                        n++;
                    }
                }
                mean = ((double)sum / n);
                d = 0.0;

                for (int i = 0; i < srcData.Height - size; i++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (i * srcData.Stride);
                    byte* tptr = (byte*)bitmapData.Scan0 + (i * bitmapData.Stride);

                    for (int j = 0; j < srcData.Width - size; j++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((i + l) * srcData.Stride);
                                c = (tempPtr[((j + k) * offset)] + tempPtr[((j + k) * offset) + 1] + tempPtr[((j + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        s = (mean - nTemp);
                        d += (s * s);
                    }
                }


                d = d / (n - 1);
                d = Math.Sqrt(d);
                d = d * 2;

                for (int colm = mdl; colm < srcData.Height - mdl; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = mdl; row < srcData.Width - mdl; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = (mdl * -1); k < mdl; k++)
                        {
                            for (l = (mdl * -1); l < mdl; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[mdl + k, mdl + l];

                            }
                        }

                        if (nTemp > d)
                        {
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 255;
                        }
                        else
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 0;

                    }
                }
            }

            bitmap.UnlockBits(bitmapData);
            SrcImage.UnlockBits(srcData);

            return bitmap;
        }

        public Bitmap LoG7x7(Bitmap SrcImage)
        {
            double[,] MASK = new double[7, 7] {
                                {-5,-6,-5.5,-5,-5.5,-6,-5},
                                {-6,-5,-2,0.8,-2,-5,-6},
                                {-5.5,-2,0.4,0.4,0.4,-2,-5.5},
                                {-5,0.8,0.4,225,0.4,0.8,-5},
                                {-5.5,-2,0.4,0.4,0.4,-2,-5.5},
                                {-6,-5,-2,0.8,-2,-5,-6},
                                {-5,-6,-5.5,-5,-5.5,-6,-5},

                            };

            double nTemp = 0.0;
            double c = 0;

            int mdl, size;
            size = 7;
            mdl = size / 2;

            double min, max;
            min = max = 0.0;

            double sum = 0.0;
            double mean;
            double d = 0.0;
            double s = 0.0;
            int n = 0;

            Bitmap bitmap = new Bitmap(SrcImage.Width + mdl, SrcImage.Height + mdl);
            int l, k;

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData srcData = SrcImage.LockBits(new Rectangle(0, 0, SrcImage.Width, SrcImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                int offset = 3;

                for (int colm = 0; colm < srcData.Height - size; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = 0; row < srcData.Width - size; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        sum += nTemp;
                        n++;
                    }
                }
                mean = ((double)sum / n);
                d = 0.0;

                for (int i = 0; i < srcData.Height - size; i++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (i * srcData.Stride);
                    byte* tptr = (byte*)bitmapData.Scan0 + (i * bitmapData.Stride);

                    for (int j = 0; j < srcData.Width - size; j++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((i + l) * srcData.Stride);
                                c = (tempPtr[((j + k) * offset)] + tempPtr[((j + k) * offset) + 1] + tempPtr[((j + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        s = (mean - nTemp);
                        d += (s * s);
                    }
                }


                d = d / (n - 1);
                d = Math.Sqrt(d);
                d = d * 2;

                for (int colm = mdl; colm < srcData.Height - mdl; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = mdl; row < srcData.Width - mdl; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = (mdl * -1); k < mdl; k++)
                        {
                            for (l = (mdl * -1); l < mdl; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[mdl + k, mdl + l];

                            }
                        }

                        if (nTemp > d)
                        {
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 255;
                        }
                        else
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 0;

                    }
                }
            }

            bitmap.UnlockBits(bitmapData);
            SrcImage.UnlockBits(srcData);

            return bitmap;
        }
        public Bitmap LoG3x3(Bitmap SrcImage, double[,] MASK)
        {

            double nTemp = 0.0;
            double c = 0;

            int mdl, size;
            size = 3;
            mdl = size / 2;

            double min, max;
            min = max = 0.0;

            double sum = 0.0;
            double mean;
            double d = 0.0;
            double s = 0.0;
            int n = 0;

            Bitmap bitmap = new Bitmap(SrcImage.Width + mdl, SrcImage.Height + mdl);
            int l, k;

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData srcData = SrcImage.LockBits(new Rectangle(0, 0, SrcImage.Width, SrcImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                int offset = 3;

                for (int colm = 0; colm < srcData.Height - size; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = 0; row < srcData.Width - size; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        sum += nTemp;
                        n++;
                    }
                }
                mean = ((double)sum / n);
                d = 0.0;

                for (int i = 0; i < srcData.Height - size; i++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (i * srcData.Stride);
                    byte* tptr = (byte*)bitmapData.Scan0 + (i * bitmapData.Stride);

                    for (int j = 0; j < srcData.Width - size; j++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = 0; k < size; k++)
                        {
                            for (l = 0; l < size; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((i + l) * srcData.Stride);
                                c = (tempPtr[((j + k) * offset)] + tempPtr[((j + k) * offset) + 1] + tempPtr[((j + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[k, l];

                            }
                        }

                        s = (mean - nTemp);
                        d += (s * s);
                    }
                }


                d = d / (n - 1);
                d = Math.Sqrt(d);
                d = d * 2;

                for (int colm = mdl; colm < srcData.Height - mdl; colm++)
                {
                    byte* ptr = (byte*)srcData.Scan0 + (colm * srcData.Stride);
                    byte* bitmapPtr = (byte*)bitmapData.Scan0 + (colm * bitmapData.Stride);

                    for (int row = mdl; row < srcData.Width - mdl; row++)
                    {
                        nTemp = 0.0;

                        min = double.MaxValue;
                        max = double.MinValue;

                        for (k = (mdl * -1); k < mdl; k++)
                        {
                            for (l = (mdl * -1); l < mdl; l++)
                            {
                                byte* tempPtr = (byte*)srcData.Scan0 + ((colm + l) * srcData.Stride);
                                c = (tempPtr[((row + k) * offset)] + tempPtr[((row + k) * offset) + 1] + tempPtr[((row + k) * offset) + 2]) / 3;

                                nTemp += (double)c * MASK[mdl + k, mdl + l];

                            }
                        }

                        if (nTemp > d)
                        {
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 255;
                        }
                        else
                            bitmapPtr[row * offset] = bitmapPtr[row * offset + 1] = bitmapPtr[row * offset + 2] = 0;

                    }
                }
            }

            bitmap.UnlockBits(bitmapData);
            SrcImage.UnlockBits(srcData);

            return bitmap;
        }

        public Bitmap ApplyColorMatrix(Bitmap sourceImage, ColorMatrix colorMatrix)
        {


            //Bitmap  = sourceImage.Clone as Bitmap;
            Bitmap finalImage = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);


            using (Graphics graphics = Graphics.FromImage(finalImage))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                                    0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, bmpAttributes);


            }


            sourceImage.Dispose();


            return finalImage;
        }
        public bool Conv3x3(Bitmap b, double[,] m)
        {
            // Avoid divide by zero errors
            int factor = 1;
            int offset = 0;
            if (0 == factor) return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB. 
            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                               ImageLockMode.ReadWrite,
                               PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = (int)((((pSrc[2] * m[0, 0]) +
                            (pSrc[5] * m[0,1]) +
                            (pSrc[8] * m[0,2]) +
                            (pSrc[2 + stride] * m[1, 0]) +
                            (pSrc[5 + stride] * m[1, 1]) +
                            (pSrc[8 + stride] * m[1, 2]) +
                            (pSrc[2 + stride2] * m[2, 0]) +
                            (pSrc[5 + stride2] * m[2, 1]) +
                            (pSrc[8 + stride2] * m[2, 2])) / factor) + offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;

                        nPixel = (int)((((pSrc[1] * m[0, 0]) +
                            (pSrc[4] * m[0, 1]) +
                            (pSrc[7] * m[0, 2]) +
                            (pSrc[1 + stride] * m[1, 0]) +
                            (pSrc[4 + stride] * m[1, 1]) +
                            (pSrc[7 + stride] * m[1, 2]) +
                            (pSrc[1 + stride2] * m[2, 0]) +
                            (pSrc[4 + stride2] * m[2, 0]) +
                            (pSrc[7 + stride2] * m[2, 2])) / factor) + offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[4 + stride] = (byte)nPixel;
                        
                        nPixel = (int)((((pSrc[0] * m[0, 0]) +(pSrc[3] * m[0, 1]) + (pSrc[6] * m[0, 2]) +
                                       (pSrc[0 + stride] * m[1, 0]) +
                                       (pSrc[3 + stride] * m[1, 1]) +
                                       (pSrc[6 + stride] * m[1, 2]) +
                                       (pSrc[0 + stride2] * m[2, 0]) +
                                       (pSrc[3 + stride2] * m[2, 1]) +
                                       (pSrc[6 + stride2] * m[2, 2])) / factor) + offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[3 + stride] = (byte)nPixel;
                        
                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
    }


}


