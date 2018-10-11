using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2DObjects
{
    public class Line : DrawingObjects
    {
        protected int x0, y0, x1, y1;

        public Line(int a, int b, int c, int d)
        {
            x0 = a; y0 = b; x1 = c; y1 = d;
        }

        public override void Render(Graphics g, int idAlgo)
        {
            if (idAlgo == 0)
                DDARender(g);
            else if (idAlgo == 1)
                BresenhamRender(g);
            else if (idAlgo == 2)
                MidPointRender(g);
            else if (idAlgo == 3)
                XiaolinWuRender(g);
        }

        protected override void DDARender(Graphics g)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            double deltax = dx / (double)steps;
            double deltay = dy / (double)steps;

            for (int i = 0; i <= steps; ++i)
            {
                double x_i = x0 + deltax * i;
                double y_i = y0 + deltay * i;
                SketchForm.SetPixel(g, Color.Red, (int) Math.Round(x_i), (int) Math.Round(y_i));
            }
        }

        protected override void BresenhamRender(Graphics g)
        {
            int dx = x1 - x0, stepx = 1; 
            if (dx < 0) // Doi xung qua duong thang d = y0
            {
                dx = -dx;
                stepx = -1;
            }

            int dy = y1 - y0, stepy = 1;
            if (dy < 0) // Doi xung qua duong thang d = x0
            {
                dy = -dy;
                stepy = -1;
            }

            if (dx > dy)
            {
                int p = 2 * dy - dx;

                while (true)
                {
                    SketchForm.SetPixel(g, Color.Blue, x0, y0);

                    if (x0 == x1 && y0 == y1) break;

                    x0 += stepx;
                    if (p >= 0)
                    {
                        p += 2 * dy - 2 * dx;
                        y0 += stepy;
                    }
                    else
                    {
                        p += 2 * dy;
                    }
                }
            }
            else
            {
                int p = 2 * dx - dy;

                while (true)
                {
                    SketchForm.SetPixel(g, Color.Blue, x0, y0);

                    if (x0 == x1 && y0 == y1) break;

                    y0 += stepy;
                    if (p >= 0)
                    {
                        p += 2 * dx - 2 * dy;
                        x0 += stepx;
                    }
                    else
                    {
                        p += 2 * dx;
                    }
                }
            }
        }

        protected override void MidPointRender(Graphics g)
        {
            int dx = x1 - x0, stepx = 1;
            if (dx < 0) // Doi xung qua duong thang d = y0
            {
                dx = -dx;
                stepx = -1;
            }

            int dy = y1 - y0, stepy = 1;
            if (dy < 0) // Doi xung qua duong thang d = x0
            {
                dy = -dy;
                stepy = -1;
            }

            if (dx > dy)
            {
                int p = 2 * dy - dx;

                while (true)
                {
                    SketchForm.SetPixel(g, Color.Green, x0, y0);

                    if (x0 == x1 && y0 == y1) break;

                    x0 += stepx;
                    if (p >= 0)
                    {
                        p += 2 * dy - 2 * dx;
                        y0 += stepy;
                    }
                    else
                    {
                        p += 2 * dy;
                    }
                }
            }
            else
            {
                int p = 2 * dx - dy;

                while (true)
                {
                    SketchForm.SetPixel(g, Color.Green, x0, y0);

                    if (x0 == x1 && y0 == y1) break;

                    y0 += stepy;
                    if (p >= 0)
                    {
                        p += 2 * dx - 2 * dy;
                        x0 += stepx;
                    }
                    else
                    {
                        p += 2 * dx;
                    }
                }
            }
        }

        protected void XiaolinWuRender(Graphics g)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            double deltax = dx / (double)steps;
            double deltay = dy / (double)steps;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                int sign_x = (dx >= 0 ? 1 : -1);
                for (int i = 0; i <= steps; ++i)
                {
                    int x_i = x0 + sign_x * i;
                    double y_i = y0 + deltay * i;

                    int ry_i = (int)y_i - (y_i > 0 ? 0 : 1);
                    int p = (int)(255 * (y_i - ry_i));

                    SketchForm.SetPixel(g, Color.FromArgb(255 - p, 0, 255 - p), x_i, ry_i);
                    SketchForm.SetPixel(g, Color.FromArgb(p, 0, p), x_i, ry_i + 1);
                }
            }
            else
            {
                int sign_y = (dy >= 0 ? 1 : -1);
                for (int i = 0; i <= steps; ++i)
                {
                    int y_i = y0 + sign_y * i;
                    double x_i = x0 + deltax * i;

                    int rx_i = (int)x_i - (x_i > 0 ? 0 : 1);
                    int p = (int)(255 * (x_i - rx_i));

                    SketchForm.SetPixel(g, Color.FromArgb(255 - p, 0, 255 - p), rx_i, y_i);
                    SketchForm.SetPixel(g, Color.FromArgb(p, 0, p), rx_i + 1, y_i);
                }
            }
        }
    }
}
