using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2DObjects
{
    public class Circle : DrawingObjects
    {
        protected int xc, yc, r;

        public Circle(int a, int b, int c)
        {
            xc = a; yc = b; r = c;
        }

        protected override void DDARender(Graphics g)
        {
            for (int x = 0; x < r; ++x)
            {
                double y = Math.Sqrt(r * r - x * x);
                Set8Pixels(g, Color.Red, x, (int)Math.Round(y));
            }
        }

        protected override void BresenhamRender(Graphics g) 
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            while (x <= y)
            {
                Set8Pixels(g, Color.Blue, x, y);
                ++x;

                if (d > 0)
                {
                    d += 4 * (x - y) + 10;
                    --y;
                }
                else
                {
                    d += 4 * x + 6;
                }
            }
        }

        protected override void MidPointRender(Graphics g)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            while (x <= y)
            {
                Set8Pixels(g, Color.Green, x, y);
                ++x;

                if (d > 0)
                {
                    d += 4 * (x - y) + 10;
                    --y;
                }
                else
                {
                    d += 4 * x + 6;
                }
            }
        }

        private void Set8Pixels(Graphics g, Color c, int x, int y)
        {
            SketchForm.SetPixel(g, c, xc + x, yc + y);
            SketchForm.SetPixel(g, c, xc - x, yc + y);
            SketchForm.SetPixel(g, c, xc + x, yc - y);
            SketchForm.SetPixel(g, c, xc - x, yc - y);
            SketchForm.SetPixel(g, c, xc + y, yc + x);
            SketchForm.SetPixel(g, c, xc - y, yc + x);
            SketchForm.SetPixel(g, c, xc + y, yc - x);
            SketchForm.SetPixel(g, c, xc - y, yc - x);
        }
    }
}
