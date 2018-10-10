using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2DObjects
{
    class Ellipse : DrawingObjects
    {
        protected int xc, yc, a, b;

        public Ellipse(int p1, int p2, int p3, int p4)
        {
            xc = p1; yc = p2;
            a = p3; b = p4;
        }

        protected override void DDARender(Graphics g)
        {
            int x, y;
            x = 0; y = b;
            while (sqr(b) * x <= sqr(a) * y)
            {
                Set4Pixels(g, Color.Red, x, y);
                ++x;
                y = (int)Math.Round(Math.Sqrt(sqr(a * b) - sqr(b * x)) / (float)a);
            }
            while (y >= 0)
            {
                Set4Pixels(g, Color.Red, x, y);
                --y;
                x = (int)Math.Round(Math.Sqrt(sqr(a * b) - sqr(a * y)) / (float)b);
            }
        }

        protected override void BresenhamRender(Graphics g)
        {
            int x, y, p;

            x = 0; y = b;
            p = 2 * sqr(a * b) - 2 * sqr(a) * b + sqr(a) - 2 * sqr(b) * (sqr(a) - 1);

            while (sqr(b) * x <= sqr(a) * y)
            {
                Set4Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 * sqr(b) * (2 * x + 5) - 4 * sqr(a) * (y - 1);
                    ++x;
                    --y;
                }
                else
                {
                    p += 2 * sqr(b) * (2 * x + 5);
                    ++x;
                }
            }

            x = a; y = 0;
            p = 2 * sqr(a * b) - 2 * sqr(b) * a + sqr(b) - 2 * sqr(a) * (sqr(b) - 1);

            while (sqr(b) * x > sqr(a) * y)
            {
                Set4Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 * sqr(a) * (2 * y + 5) - 4 * sqr(b) * (x - 1);
                    ++y;
                    --x;
                }
                else
                {
                    p += 2 * sqr(a) * (2 * y + 5);
                    ++y;
                }
            }
        }

        protected override void MidPointRender(Graphics g)
        {
            int x, y, p;

            x = 0; y = b;
            p = 4 * sqr(b) + sqr(a) - 4 * sqr(a) * b;

            while (sqr(b) * x <= sqr(a) * y)
            {
                Set4Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += 4 * sqr(b) * (2 * x + 3) - 8 * sqr(a) * (y - 1);
                    ++x;
                    --y;
                }
                else
                {
                    p += 4 * sqr(b) * (2 * x + 3);
                    ++x;
                }
            }

            x = a; y = 0;
            p = 4 * sqr(a) + sqr(b) - 4 * sqr(b) * a;

            while (sqr(b) * x > sqr(a) * y)
            {
                Set4Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += 4 * sqr(a) * (2 * y + 3) - 8 * sqr(b) * (x - 1);
                    ++y;
                    --x;
                }
                else
                {
                    p += 4 * sqr(a) * (2 * y + 3);
                    ++y;
                }
            }
        }

        private void Set4Pixels(Graphics g, Color c, int x, int y)
        {
            SketchForm.SetPixel(g, c, xc + x, yc + y);
            SketchForm.SetPixel(g, c, xc + x, yc - y);
            SketchForm.SetPixel(g, c, xc - x, yc + y);
            SketchForm.SetPixel(g, c, xc - x, yc - y);
        }

        private int sqr(int x)
        {
            return x * x;
        }
    }
}
