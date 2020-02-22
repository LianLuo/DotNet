using AForge.Video;
using AForge.Video.FFMPEG;
using Kogel.Record;
using Kogel.Record.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace RecordScreenDemo
{
    public partial class MainView : Form
    {
        private IRecorder recorder { get; set; }
        private string recorderPath { get; set; }
        public MainView()
        {
            InitializeComponent();

            recorderPath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("MMddHHmmss") + ".avi";
            recorder = new ScreenRecorderExtension(recorderPath, 10, true);
        }

        int totalFrame = 1;
        private void VideoStreamer_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.picScreen.Image = (Bitmap)eventArgs.Frame.Clone();
            try
            {
                this.lbMsg.Invoke(new EventHandler((s, e) => {
                    this.lbMsg.Text = (totalFrame++).ToString();
                }));
            }
            catch { }
        }

        

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            recorder.Start(VideoStreamer_NewFrame);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            recorder.End();
        }

        private void btnOpenProgram_Click(object sender, EventArgs e)
        {
            //new frmProgram().Show();
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            new FrmCamera().Show();
        }
    }

    public class ScreenRecorderExtension : ScreenRecorder
    {
        public ScreenRecorderExtension(string aviFilePath, int defaultFrameRate = 10, bool isLoopingWav = false, VideoCodec videoCodec = VideoCodec.MSMPEG4v2) :base(aviFilePath, defaultFrameRate, isLoopingWav, videoCodec)
        {

        }

        Pen mousePen = new Pen(new SolidBrush(Color.Black));

        protected override void VideoStreamer_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = eventArgs.Frame;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawEllipse(mousePen, new Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 10, 10));
            }
            base.VideoStreamer_NewFrame(sender, new NewFrameEventArgs(bitmap));
        }
    }
}
