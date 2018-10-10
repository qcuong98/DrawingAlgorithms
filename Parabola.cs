using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw2DObjects
{
    class Parabola : DrawingObjects
    {
        protected double a, b, c;
        private int sign, d_x, d_y;

        public Parabola(double p1, double p2, double p3)
        {
            a = p1;
            b = p2;
            c = p3;
        }

        public override void Render(Graphics g, int idAlgo)
        {
            sign = 1;
            if (a < 0)
            {
                a *= -1;
                b *= -1;
                c *= -1;
                sign = -1;
            }
            d_x = (int)Math.Round(-b / (2.0 * a));
            d_y = (int)Math.Round(c - sqr(-b / (2.0 * a)));

            if (idAlgo == 0)
                DDARender(g);
            else if (idAlgo == 1)
                BresenhamRender(g);
            else if (idAlgo == 2)
                MidPointRender(g);
        }

        protected override void DDARender(Graphics g)
        {
            int x = 0, y = 0;

            while (2 * a * x <= 1 && x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Red, x, y);
                ++x;
                y = (int)Math.Round(a * sqr(x));
            }

            while (x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Red, x, y);
                ++y;
                x = (int)Math.Round(Math.Sqrt(y / a));
            }
        }

        protected override void BresenhamRender(Graphics g)
        {
            int x, y; double p;

            x = 0; y = 0;
            p = 2 * a - 1;

            while (2 * a * x <= 1 && x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 * a * (2 * x + 3) - 2;
                    ++x;
                    y += 1;
                }
                else
                {
                    p += 2 * a * (2 * x + 3);
                    ++x;
                }
            }

            p = 2 * (y + 1) - 2 * a * sqr(x + 0.5);
            while (x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 - 2 * a * (2 * x + 2);
                    ++x;
                    ++y;
                }
                else
                {
                    p += 2;
                    ++y;
                }
            }   
        }

        protected override void MidPointRender(Graphics g)
        {
            int x, y; double p;

            x = 0; y = 0;
            p = a - 0.5;

            while (2 * a * x <= 1 && x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += a * (2 * x + 3) - 1;
                    ++x;
                    y += 1;
                }
                else
                {
                    p += a * (2 * x + 3);
                    ++x;
                }
            }

            p =  (y + 1) - a * sqr(x + 0.5);
            while (x <= SketchForm.WIDTH / 2)
            {
                Set2Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += 1 - a * (2 * x + 2);
                    ++x;
                    ++y;
                }
                else
                {
                    p += 1;
                    ++y;
                }
            }
        }

        private void Set2Pixels(Graphics g, Color C, int x, int y)
        {
            if (sign == 1)
            {
                SketchForm.SetPixel(g, C, d_x + x, d_y + y);
                SketchForm.SetPixel(g, C, d_x - x, d_y + y);
            }
            else
            {
                SketchForm.SetPixel(g, C, d_x + x, - d_y - y);
                SketchForm.SetPixel(g, C, d_x - x, - d_y - y);
            }
        }

        private double sqr(double p)
        {
            return p * p;
        }
    }
}
