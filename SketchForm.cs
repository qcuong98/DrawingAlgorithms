using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw2DObjects
{
    public partial class SketchForm : Form
    {
        Graphics g;
        static public int WIDTH = 600;
        static public int HEIGHT = 400;

        public SketchForm()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(700, 100);

            this.ClientSize = new Size(WIDTH, HEIGHT);
        }

        public void Drawing(DrawingObjects CurObject, int idAlgo)
        {
            CurObject.Render(g, idAlgo);
        }

        internal static void SetPixel(Graphics g, Color c, int x, int y)
        {
            int px, py;   
            try {
                px = x + WIDTH / 2;
                py = -y + HEIGHT / 2;
            }
            catch (OverflowException)
            {
                return;
            }

            if (0 <= px && px <= WIDTH && 0 <= py && py <= HEIGHT)
            {
                SolidBrush myBrush = new SolidBrush(c);
                g.FillRectangle(myBrush, px, py, 1, 1);
            }
        }

        private void SketchForm_Paint(object sender, PaintEventArgs e)
        {
            // O(0, 0)
            SolidBrush myBrush = new SolidBrush(Color.Black);
            g.FillEllipse(myBrush, WIDTH / 2 - 2, HEIGHT / 2 - 2, 5, 5);
            g.FillRectangle(myBrush, 0, HEIGHT, WIDTH, 1);
        }
    }
}
