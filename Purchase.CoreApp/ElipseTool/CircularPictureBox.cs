using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElipseTool
{
    public class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using(GraphicsPath g = new GraphicsPath())
            {
                g.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new System.Drawing.Region(g);
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pe.Graphics.DrawEllipse(new System.Drawing.Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
