using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2DObjects
{
    abstract public class DrawingObjects {

        public virtual void Render(Graphics g, int idAlgo)
        {
            if (idAlgo == 0)
                DDARender(g);
            else if (idAlgo == 1)
                BresenhamRender(g);
            else if (idAlgo == 2)
                MidPointRender(g);
        }

        abstract protected void DDARender(Graphics g);
        abstract protected void BresenhamRender(Graphics g);
        abstract protected void MidPointRender(Graphics g);
    }
}
