using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw2DObjects
{
    class Hyperbola : DrawingObjects
    {
        protected int xc, yc, a, b;

        public Hyperbola(int p1, int p2, int p3, int p4)
        {
            xc = p1; yc = p2;
            a = p3; b = p4;
        }

        protected override void DDARender(Graphics g)
        {
            int x, y;
            x = a; y = 0;
            while (sqr(b) * x >= sqr(a) * y && x <= SketchForm.WIDTH / 2)
            {
                Set4Pixels(g, Color.Red, x, y);
                ++y;
                x = (int)Math.Round(Math.Sqrt(sqr(a * b) + sqr(a * y)) / (float)b);
            }

            while (x <= SketchForm.WIDTH / 2)
            {
                Set4Pixels(g, Color.Red, x, y);
                ++x;
                y = (int)Math.Round(Math.Sqrt(sqr(b * x) - sqr(a * b)) / (float)a);
            }
        }

        protected override void BresenhamRender(Graphics g)
        {
            int x, y, p;

            x = a; y = 0;
            p = 2 * sqr(a) * (sqr(b) + 1) - sqr(b) * (2 * sqr(a) + 2 * a + 1);

            while (sqr(b) * x >= sqr(a) * y && x <= SketchForm.WIDTH)
            {
                Set4Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 * sqr(a) * (2 * y + 3) - 2 * sqr(b) * (2 * x + 2);
                    ++y;
                    ++x;
                }
                else
                {
                    p += 2 * sqr(a) * (2 * y + 3);
                    ++y;
                }
            }

            p = 2 * sqr(b) * (sqr(x + 1) - sqr(a)) - sqr(a) * (2 * sqr(y) + 2 * y + 1);
             
            while (x <= SketchForm.WIDTH)
            {
                Set4Pixels(g, Color.Blue, x, y);
                if (p >= 0)
                {
                    p += 2 * sqr(b) * (2 * x + 3) - 2 * sqr(a) * (2 * y + 2);
                    ++x;
                    ++y;
                }
                else
                {
                    p += 2 * sqr(b) * (2 * x + 3);
                    ++x;
                }
            }
        }

        protected override void MidPointRender(Graphics g)
        {
            int x, y, p;

            x = a; y = 0;
            p = sqr(2 * a * b) - sqr(b * (2 * a + 1)) + sqr(2 * a);

            while (sqr(b) * x >= sqr(a) * y && x <= SketchForm.WIDTH)
            {
                Set4Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += sqr(2 * a) * (2 * y + 3) - sqr(2 * b) * (2 * x + 2);
                    ++y;
                    ++x;
                }
                else
                {
                    p += sqr(2 * a) * (2 * y + 3);
                    ++y;
                }
            }

            p = sqr(2 * b * (x + 1)) - sqr(a * (2 * y + 1)) - sqr(2 * a * b);

            while (x <= SketchForm.WIDTH)
            {
                Set4Pixels(g, Color.Green, x, y);
                if (p >= 0)
                {
                    p += sqr(2 * b) * (2 * x + 3) - sqr(2 * a) * (2 * y + 2);
                    ++x;
                    ++y;
                }
                else
                {
                    p += sqr(2 * b) * (2 * x + 3);
                    ++x;
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
