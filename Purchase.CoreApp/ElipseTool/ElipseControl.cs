using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElipseTool
{
    class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthElipse,
                int nHeightElipse
            );

        private Control _cntrl;
        private int _CnrnerRadius = 30;

        public Control TargetControl
        {
            get { return this._cntrl; }
            set
            {
                this._cntrl = value;
                this._cntrl.SizeChanged += (sender, agrs) => {
                    this._cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this._cntrl.Width, this._cntrl.Height, this._CnrnerRadius, this._CnrnerRadius));
                };
            }
        }

        public int CornerRadius
        {
            get { return this._CnrnerRadius; }
            set
            {
                this._CnrnerRadius = value;
                if(this._cntrl != null)
                {
                    this._cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this._cntrl.Width, this._cntrl.Height, this._CnrnerRadius, this._CnrnerRadius));
                }                
            }
        }
    }
}
