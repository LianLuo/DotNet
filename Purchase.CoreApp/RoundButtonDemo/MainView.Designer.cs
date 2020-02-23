using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RoundButtonDemo.Properties;

namespace RoundButtonDemo
{
    partial class MainView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.btnCall = new RoundButtonDemo.RoundButton();
            this.btnCar = new RoundButtonDemo.RoundButton();
            this.btnSay = new RoundButtonDemo.RoundButton();
            this.btnSay1 = new RoundButtonDemo.RoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(868, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(65, 140);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(262, 334);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(48, 7);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(83, 115);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTitle.TabIndex = 1;
            this.picTitle.TabStop = false;
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCall.FlatAppearance.BorderSize = 0;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall.ForeColor = System.Drawing.Color.White;
            this.btnCall.Image = ((System.Drawing.Image)(resources.GetObject("btnCall.Image")));
            this.btnCall.Location = new System.Drawing.Point(458, 151);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(76, 74);
            this.btnCall.TabIndex = 2;
            this.btnCall.UseVisualStyleBackColor = false;
            // 
            // btnCar
            // 
            this.btnCar.BackColor = System.Drawing.Color.Orange;
            this.btnCar.FlatAppearance.BorderSize = 0;
            this.btnCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCar.ForeColor = System.Drawing.Color.White;
            this.btnCar.Image = ((System.Drawing.Image)(resources.GetObject("btnCar.Image")));
            this.btnCar.Location = new System.Drawing.Point(540, 168);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(76, 74);
            this.btnCar.TabIndex = 2;
            this.btnCar.UseVisualStyleBackColor = false;
            // 
            // btnSay
            // 
            this.btnSay.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSay.FlatAppearance.BorderSize = 0;
            this.btnSay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSay.ForeColor = System.Drawing.Color.White;
            this.btnSay.Image = ((System.Drawing.Image)(resources.GetObject("btnSay.Image")));
            this.btnSay.Location = new System.Drawing.Point(622, 151);
            this.btnSay.Name = "btnSay";
            this.btnSay.Size = new System.Drawing.Size(76, 74);
            this.btnSay.TabIndex = 2;
            this.btnSay.UseVisualStyleBackColor = false;
            // 
            // btnSay1
            // 
            this.btnSay1.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnSay1.FlatAppearance.BorderSize = 0;
            this.btnSay1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSay1.ForeColor = System.Drawing.Color.White;
            this.btnSay1.Image = ((System.Drawing.Image)(resources.GetObject("btnSay1.Image")));
            this.btnSay1.Location = new System.Drawing.Point(704, 168);
            this.btnSay1.Name = "btnSay1";
            this.btnSay1.Size = new System.Drawing.Size(76, 74);
            this.btnSay1.TabIndex = 2;
            this.btnSay1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "C# UI Academy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cats are Angels with Whiskers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Behind every Great Person, There is a Great Cat..;) ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(424, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Read More";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(570, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add a Post";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(919, 486);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSay1);
            this.Controls.Add(this.btnSay);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox picTitle;
        private RoundButton btnCall;
        private RoundButton btnCar;
        private RoundButton btnSay;
        private RoundButton btnSay1;
        private Button btnClose;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}

