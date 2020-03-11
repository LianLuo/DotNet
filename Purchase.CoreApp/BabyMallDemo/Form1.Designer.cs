namespace BabyMallDemo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.circleButton1 = new BabyMallDemo.CircleButton();
            this.circleButton2 = new BabyMallDemo.CircleButton();
            this.circleButton3 = new BabyMallDemo.CircleButton();
            this.circleButton4 = new BabyMallDemo.CircleButton();
            this.circleButton5 = new BabyMallDemo.CircleButton();
            this.circleButton6 = new BabyMallDemo.CircleButton();
            this.dragControl1 = new BabyMallDemo.DragControl();
            this.sidePic = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePic)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.button4);
            this.panelTitle.Controls.Add(this.button3);
            this.panelTitle.Controls.Add(this.button2);
            this.panelTitle.Controls.Add(this.button1);
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(919, 74);
            this.panelTitle.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.circleButton6);
            this.panel2.Controls.Add(this.circleButton5);
            this.panel2.Controls.Add(this.circleButton4);
            this.panel2.Controls.Add(this.circleButton3);
            this.panel2.Controls.Add(this.circleButton2);
            this.panel2.Controls.Add(this.circleButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 89);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.sidePic);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(919, 345);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(24)))), ((int)(((byte)(47)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(300, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(205)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(453, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Products";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(606, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 41);
            this.button3.TabIndex = 1;
            this.button3.Text = "Categories";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(63)))), ((int)(((byte)(146)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(759, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 41);
            this.button4.TabIndex = 1;
            this.button4.Text = "Contact Us";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // circleButton1
            // 
            this.circleButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(63)))), ((int)(((byte)(146)))));
            this.circleButton1.FlatAppearance.BorderSize = 0;
            this.circleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton1.ForeColor = System.Drawing.Color.White;
            this.circleButton1.Location = new System.Drawing.Point(292, 6);
            this.circleButton1.Name = "circleButton1";
            this.circleButton1.Size = new System.Drawing.Size(83, 83);
            this.circleButton1.TabIndex = 0;
            this.circleButton1.Text = "Toys";
            this.circleButton1.UseVisualStyleBackColor = false;
            // 
            // circleButton2
            // 
            this.circleButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.circleButton2.FlatAppearance.BorderSize = 0;
            this.circleButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton2.ForeColor = System.Drawing.Color.White;
            this.circleButton2.Location = new System.Drawing.Point(395, 6);
            this.circleButton2.Name = "circleButton2";
            this.circleButton2.Size = new System.Drawing.Size(83, 83);
            this.circleButton2.TabIndex = 0;
            this.circleButton2.Text = "Teddy";
            this.circleButton2.UseVisualStyleBackColor = false;
            // 
            // circleButton3
            // 
            this.circleButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(205)))));
            this.circleButton3.FlatAppearance.BorderSize = 0;
            this.circleButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton3.ForeColor = System.Drawing.Color.White;
            this.circleButton3.Location = new System.Drawing.Point(498, 6);
            this.circleButton3.Name = "circleButton3";
            this.circleButton3.Size = new System.Drawing.Size(83, 83);
            this.circleButton3.TabIndex = 0;
            this.circleButton3.Text = "Dolls";
            this.circleButton3.UseVisualStyleBackColor = false;
            // 
            // circleButton4
            // 
            this.circleButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(24)))), ((int)(((byte)(47)))));
            this.circleButton4.FlatAppearance.BorderSize = 0;
            this.circleButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton4.ForeColor = System.Drawing.Color.White;
            this.circleButton4.Location = new System.Drawing.Point(601, 6);
            this.circleButton4.Name = "circleButton4";
            this.circleButton4.Size = new System.Drawing.Size(83, 83);
            this.circleButton4.TabIndex = 0;
            this.circleButton4.Text = "Cars";
            this.circleButton4.UseVisualStyleBackColor = false;
            // 
            // circleButton5
            // 
            this.circleButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(205)))));
            this.circleButton5.FlatAppearance.BorderSize = 0;
            this.circleButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton5.ForeColor = System.Drawing.Color.White;
            this.circleButton5.Location = new System.Drawing.Point(704, 6);
            this.circleButton5.Name = "circleButton5";
            this.circleButton5.Size = new System.Drawing.Size(83, 83);
            this.circleButton5.TabIndex = 0;
            this.circleButton5.Text = "Guns";
            this.circleButton5.UseVisualStyleBackColor = false;
            // 
            // circleButton6
            // 
            this.circleButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(169)))), ((int)(((byte)(0)))));
            this.circleButton6.FlatAppearance.BorderSize = 0;
            this.circleButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleButton6.ForeColor = System.Drawing.Color.White;
            this.circleButton6.Location = new System.Drawing.Point(807, 6);
            this.circleButton6.Name = "circleButton6";
            this.circleButton6.Size = new System.Drawing.Size(83, 83);
            this.circleButton6.TabIndex = 0;
            this.circleButton6.Text = "Others";
            this.circleButton6.UseVisualStyleBackColor = false;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.panelTitle;
            // 
            // sidePic
            // 
            this.sidePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePic.Image = ((System.Drawing.Image)(resources.GetObject("sidePic.Image")));
            this.sidePic.Location = new System.Drawing.Point(0, 0);
            this.sidePic.Name = "sidePic";
            this.sidePic.Size = new System.Drawing.Size(919, 345);
            this.sidePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidePic.TabIndex = 0;
            this.sidePic.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(919, 508);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTitle.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private CircleButton circleButton1;
        private CircleButton circleButton6;
        private CircleButton circleButton5;
        private CircleButton circleButton4;
        private CircleButton circleButton3;
        private CircleButton circleButton2;
        private DragControl dragControl1;
        private System.Windows.Forms.PictureBox sidePic;
        private System.Windows.Forms.Timer timer1;
    }
}

