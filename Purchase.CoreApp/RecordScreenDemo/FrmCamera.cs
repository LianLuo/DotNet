using AForge.Video;
using Kogel.Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordScreenDemo
{
    public partial class FrmCamera : Form
    {
        private CameraRecorder recorder { get; set; }
        private string recorderPath { get; set; }

        public FrmCamera()
        {
            InitializeComponent();

            recorderPath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("MMddHHmmss") + ".mp4";
            recorder = new CameraRecorder(recorderPath, 10, true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            recorder.Start(VideoScreemer_NewFrame);
        }

        private void VideoScreemer_NewFrame(object sender, NewFrameEventArgs e)
        {
            this.picImage.Image = (Bitmap)e.Frame.Clone();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            recorder.End();
        }
    }
}
