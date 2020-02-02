using CustomerAlterBoxDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerAlterBoxDemo
{
    public partial class Form_Alter : Form
    {
        public Form_Alter()
        {
            InitializeComponent();
        }

        public enum EnumAction
        {
            Wait,
            Start,
            Close
        }

        public enum EnumType
        {
            Success,
            Info,
            Warning,
            Error
        }

        private EnumAction action;

        private int x, y;


        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case EnumAction.Wait:
                    timer1.Interval = 5000;
                    action = EnumAction.Close;
                    break;
                case EnumAction.Start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if(this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if(this.Opacity == 1.0)
                        {
                            action = EnumAction.Wait;
                        }
                    }
                    break;
                case EnumAction.Close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if(base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1;
            action = EnumAction.Close;
        }

        public void ShowAlter(string msg, EnumType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for(int i = 1; i < 10; i++)
            {
                fname = "alter " + i.ToString();
                Form_Alter frm = (Form_Alter)Application.OpenForms[fname];
                if(frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case EnumType.Success:
                    this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case EnumType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case EnumType.Info:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case EnumType.Warning:
                    this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.lbMessage.Text = msg;
            this.Show();
            this.action = EnumAction.Start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
