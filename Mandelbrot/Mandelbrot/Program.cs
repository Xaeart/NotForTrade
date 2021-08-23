using System;
using System.Drawing;

namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        // Draw the Mandelbrot set.
        private void DrawMandelbrot()
        {
            // Work until the magnitude squared > 4.
            const int MAX_MAG_SQUARED = 4;

            // Make a Bitmap to draw on.
            m_Bm = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            Graphics gr = Graphics.FromImage(m_Bm);

            // Clear.
            gr.Clear(picCanvas.BackColor);
            picCanvas.Image = m_Bm;
            Application.DoEvents();

            // Adjust the coordinate bounds to fit picCanvas.
            AdjustAspect();

            // dReaC is the change in the real part
            // (X value) for C. dImaC is the change in the
            // imaginary part (Y value).
            int wid = picCanvas.ClientRectangle.Width;
            int hgt = picCanvas.ClientRectangle.Height;
            double dReaC = (m_Xmax - m_Xmin) / (wid - 1);
            double dImaC = (m_Ymax - m_Ymin) / (hgt - 1);

            // Calculate the values.
            int num_colors = Colors.Count;
            double ReaC = m_Xmin;
            for (int X = 0; X < wid; X++)
            {
                double ImaC = m_Ymin;
                for (int Y = 0; Y < hgt; Y++)
                {
                    double ReaZ = Zr;
                    double ImaZ = Zim;
                    double ReaZ2 = Z2r;
                    double ImaZ2 = Z2im;
                    int clr = 1;
                    while ((clr < MaxIterations) && (ReaZ2 + ImaZ2 < MAX_MAG_SQUARED))
                    {
                        // Calculate Z(clr).
                        ReaZ2 = ReaZ * ReaZ;
                        ImaZ2 = ImaZ * ImaZ;
                        ImaZ = 2 * ImaZ * ReaZ + ImaC;
                        ReaZ = ReaZ2 - ImaZ2 + ReaC;
                        clr++;
                    }

                    // Set the pixel's value.
                    m_Bm.SetPixel(X, Y, Colors[clr % num_colors]);

                    ImaC += dImaC;
                }
                ReaC += dReaC;

                // Let the user know we//re not dead.
                if (X % 10 == 0) picCanvas.Refresh();
            }

            Text = "Mandelbrot (" +
                m_Xmin.ToString("0.000000") + ", " +
                m_Ymin.ToString("0.000000") + ")-(" +
                m_Xmax.ToString("0.000000") + ", " +
                m_Ymax.ToString("0.000000") + ")";
        }

    }
}
