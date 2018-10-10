using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw2DObjects
{
    public partial class Welcome : Form
    {
        SketchForm mySketchForm;
        public Welcome()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 100);

            labelAuthor.Font = new Font(labelAuthor.Font.Name, 20);
            labelTime.Font = new Font(labelTime.Font.Name, 15);

            mySketchForm = new SketchForm();
            mySketchForm.Show();
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int x0 = CheckValid(textBoxX0.Text, ref flag);
            int y0 = CheckValid(textBoxY0.Text, ref flag);
            int x1 = CheckValid(textBoxX1.Text, ref flag);
            int y1 = CheckValid(textBoxY1.Text, ref flag);
            int n = CheckValid(textBoxNLine.Text, ref flag);

            int id = comboBoxLineAlgo.SelectedIndex;

            if (flag && id != -1)
            {
                var watch = Stopwatch.StartNew();

                for (int i = 0; i < n; ++i)
                    mySketchForm.Drawing(new Line(x0, y0, x1, y1), id);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                UpateLabelTime(elapsedMs);
            }
        }

       
        private void buttonCircle_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int xc = CheckValid(textBoxXC.Text, ref flag);
            int yc = CheckValid(textBoxYC.Text, ref flag);
            int r = CheckValid(textBoxR.Text, ref flag);
            int n = CheckValid(textBoxNCircle.Text, ref flag);

            int id = comboBoxCircleAlgo.SelectedIndex;

            if (flag && r > 0 && id != -1)
            {
                var watch = Stopwatch.StartNew();

                for (int i = 0; i < n; ++i)
                    mySketchForm.Drawing(new Circle(xc, yc, r), id);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                UpateLabelTime(elapsedMs);
            }
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int xc = CheckValid(textBoxXCEllipse.Text, ref flag);
            int yc = CheckValid(textBoxYCEllipse.Text, ref flag);
            int a = CheckValid(textBoxA.Text, ref flag);
            int b = CheckValid(textBoxB.Text, ref flag);
            int n = CheckValid(textBoxNEllipse.Text, ref flag);

            int id = comboBoxEllipseAlgo.SelectedIndex;

            if (flag && a > 0 && b > 0 && id != -1)
            {
                var watch = Stopwatch.StartNew();

                for (int i = 0; i < n; ++i)
                    mySketchForm.Drawing(new Ellipse(xc, yc, a, b), id);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                UpateLabelTime(elapsedMs);
            }
        }

        private void buttonParabola_Click(object sender, EventArgs e)
        {
            bool flag = true;
            double a = CheckValidDouble(textBoxAX2.Text, ref flag);
            double b = CheckValidDouble(textBoxBX.Text, ref flag);
            double c = CheckValidDouble(textBoxC.Text, ref flag);
            int n = CheckValid(textBoxNParabola.Text, ref flag);

            int id = comboBoxParabolaAlgo.SelectedIndex;

            if (flag && a != 0 && id != -1)
            {
                var watch = Stopwatch.StartNew();

                for (int i = 0; i < n; ++i)
                    mySketchForm.Drawing(new Parabola(a, b, c), id);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                UpateLabelTime(elapsedMs);
            }
        }


        private void buttonHyperbola_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int xc = CheckValid(textBoxXCHyperbola.Text, ref flag);
            int yc = CheckValid(textBoxYCHyperbola.Text, ref flag);
            int a = CheckValid(textBoxAHyperbola.Text, ref flag);
            int b = CheckValid(textBoxBHyperbola.Text, ref flag);
            int n = CheckValid(textBoxNHyperbola.Text, ref flag);

            int id = comboBoxHyperbolaAlgo.SelectedIndex;

            if (flag && a > 0 && b > 0 && id != -1)
            {
                var watch = Stopwatch.StartNew();

                for (int i = 0; i < n; ++i)
                    mySketchForm.Drawing(new Hyperbola(xc, yc, a, b), id);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                UpateLabelTime(elapsedMs);
            }
        }

        private void UpateLabelTime(long elapsedMs)
        {
            labelTime.Text = "Thời gian vẽ: " + elapsedMs.ToString() + " ms";
        }

        private int CheckValid(string p, ref bool flag)
        {
            int i = 0;
            try
            {
                i = System.Convert.ToInt32(p);
            }
            catch (FormatException)
            {
                flag = false;
                return 0;
            }
            catch (OverflowException)
            {
                flag = false;
                return 0;
            }
            return i;
        }

        private double CheckValidDouble(string p, ref bool flag)
        {
            double i = 0;
            try
            {
                i = System.Convert.ToDouble(p);
            }
            catch (FormatException)
            {
                flag = false;
                return 0;
            }
            catch (OverflowException)
            {
                flag = false;
                return 0;
            }
            return i;
        }
    }
}
