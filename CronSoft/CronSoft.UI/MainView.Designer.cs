namespace CronSoft.UI
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSecond = new System.Windows.Forms.TabPage();
            this.tabMins = new System.Windows.Forms.TabPage();
            this.tabHour = new System.Windows.Forms.TabPage();
            this.tabDay = new System.Windows.Forms.TabPage();
            this.tabMonth = new System.Windows.Forms.TabPage();
            this.tabWeek = new System.Windows.Forms.TabPage();
            this.tabYear = new System.Windows.Forms.TabPage();
            this.btnRun = new System.Windows.Forms.Button();
            this.lab1 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.tbExpression = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbWeek = new System.Windows.Forms.TextBox();
            this.tbMonth = new System.Windows.Forms.TextBox();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.tbHour = new System.Windows.Forms.TextBox();
            this.tbMins = new System.Windows.Forms.TextBox();
            this.tbSecond = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSecondView1 = new CronSoft.UI.UserViews.TabSecondView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSecond.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabMain);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnRun);
            this.splitContainer.Panel2.Controls.Add(this.lab1);
            this.splitContainer.Panel2.Controls.Add(this.lab2);
            this.splitContainer.Panel2.Controls.Add(this.tbExpression);
            this.splitContainer.Panel2.Controls.Add(this.tbYear);
            this.splitContainer.Panel2.Controls.Add(this.tbWeek);
            this.splitContainer.Panel2.Controls.Add(this.tbMonth);
            this.splitContainer.Panel2.Controls.Add(this.tbDay);
            this.splitContainer.Panel2.Controls.Add(this.tbHour);
            this.splitContainer.Panel2.Controls.Add(this.tbMins);
            this.splitContainer.Panel2.Controls.Add(this.tbSecond);
            this.splitContainer.Panel2.Controls.Add(this.label7);
            this.splitContainer.Panel2.Controls.Add(this.label6);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Size = new System.Drawing.Size(691, 399);
            this.splitContainer.SplitterDistance = 310;
            this.splitContainer.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSecond);
            this.tabMain.Controls.Add(this.tabMins);
            this.tabMain.Controls.Add(this.tabHour);
            this.tabMain.Controls.Add(this.tabDay);
            this.tabMain.Controls.Add(this.tabMonth);
            this.tabMain.Controls.Add(this.tabWeek);
            this.tabMain.Controls.Add(this.tabYear);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(691, 310);
            this.tabMain.TabIndex = 0;
            // 
            // tabSecond
            // 
            this.tabSecond.Controls.Add(this.tabSecondView1);
            this.tabSecond.Location = new System.Drawing.Point(4, 22);
            this.tabSecond.Name = "tabSecond";
            this.tabSecond.Padding = new System.Windows.Forms.Padding(3);
            this.tabSecond.Size = new System.Drawing.Size(683, 284);
            this.tabSecond.TabIndex = 0;
            this.tabSecond.Text = "秒";
            this.tabSecond.UseVisualStyleBackColor = true;
            // 
            // tabMins
            // 
            this.tabMins.Location = new System.Drawing.Point(4, 22);
            this.tabMins.Name = "tabMins";
            this.tabMins.Padding = new System.Windows.Forms.Padding(3);
            this.tabMins.Size = new System.Drawing.Size(683, 284);
            this.tabMins.TabIndex = 1;
            this.tabMins.Text = "分";
            this.tabMins.UseVisualStyleBackColor = true;
            // 
            // tabHour
            // 
            this.tabHour.Location = new System.Drawing.Point(4, 22);
            this.tabHour.Name = "tabHour";
            this.tabHour.Padding = new System.Windows.Forms.Padding(3);
            this.tabHour.Size = new System.Drawing.Size(683, 284);
            this.tabHour.TabIndex = 2;
            this.tabHour.Text = "小时";
            this.tabHour.UseVisualStyleBackColor = true;
            // 
            // tabDay
            // 
            this.tabDay.Location = new System.Drawing.Point(4, 22);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDay.Size = new System.Drawing.Size(683, 284);
            this.tabDay.TabIndex = 3;
            this.tabDay.Text = "天";
            this.tabDay.UseVisualStyleBackColor = true;
            // 
            // tabMonth
            // 
            this.tabMonth.Location = new System.Drawing.Point(4, 22);
            this.tabMonth.Name = "tabMonth";
            this.tabMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonth.Size = new System.Drawing.Size(683, 284);
            this.tabMonth.TabIndex = 4;
            this.tabMonth.Text = "月";
            this.tabMonth.UseVisualStyleBackColor = true;
            // 
            // tabWeek
            // 
            this.tabWeek.Location = new System.Drawing.Point(4, 22);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeek.Size = new System.Drawing.Size(683, 284);
            this.tabWeek.TabIndex = 5;
            this.tabWeek.Text = "周";
            this.tabWeek.UseVisualStyleBackColor = true;
            // 
            // tabYear
            // 
            this.tabYear.Location = new System.Drawing.Point(4, 22);
            this.tabYear.Name = "tabYear";
            this.tabYear.Padding = new System.Windows.Forms.Padding(3);
            this.tabYear.Size = new System.Drawing.Size(683, 284);
            this.tabYear.TabIndex = 6;
            this.tabYear.Text = "年";
            this.tabYear.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(502, 51);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "反解析";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(59, 56);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(83, 12);
            this.lab1.TabIndex = 10;
            this.lab1.Text = "Cron 表达式：";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(61, 26);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(77, 12);
            this.lab2.TabIndex = 9;
            this.lab2.Text = "表达式字段：";
            // 
            // tbExpression
            // 
            this.tbExpression.Location = new System.Drawing.Point(142, 52);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(352, 21);
            this.tbExpression.TabIndex = 8;
            this.tbExpression.Text = "* * * * * ?";
            // 
            // tbYear
            // 
            this.tbYear.Enabled = false;
            this.tbYear.Location = new System.Drawing.Point(520, 22);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(57, 21);
            this.tbYear.TabIndex = 7;
            this.tbYear.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbWeek
            // 
            this.tbWeek.Enabled = false;
            this.tbWeek.Location = new System.Drawing.Point(457, 22);
            this.tbWeek.Name = "tbWeek";
            this.tbWeek.Size = new System.Drawing.Size(57, 21);
            this.tbWeek.TabIndex = 6;
            this.tbWeek.Text = "?";
            this.tbWeek.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbMonth
            // 
            this.tbMonth.Enabled = false;
            this.tbMonth.Location = new System.Drawing.Point(394, 22);
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(57, 21);
            this.tbMonth.TabIndex = 5;
            this.tbMonth.Text = "*";
            this.tbMonth.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbDay
            // 
            this.tbDay.Enabled = false;
            this.tbDay.Location = new System.Drawing.Point(331, 22);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(57, 21);
            this.tbDay.TabIndex = 4;
            this.tbDay.Text = "*";
            this.tbDay.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbHour
            // 
            this.tbHour.Enabled = false;
            this.tbHour.Location = new System.Drawing.Point(268, 22);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(57, 21);
            this.tbHour.TabIndex = 3;
            this.tbHour.Text = "*";
            this.tbHour.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbMins
            // 
            this.tbMins.Enabled = false;
            this.tbMins.Location = new System.Drawing.Point(205, 22);
            this.tbMins.Name = "tbMins";
            this.tbMins.Size = new System.Drawing.Size(57, 21);
            this.tbMins.TabIndex = 2;
            this.tbMins.Text = "*";
            this.tbMins.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // tbSecond
            // 
            this.tbSecond.Enabled = false;
            this.tbSecond.Location = new System.Drawing.Point(142, 22);
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(57, 21);
            this.tbSecond.TabIndex = 1;
            this.tbSecond.Text = "*";
            this.tbSecond.TextChanged += new System.EventHandler(this.BindingTextBoxValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(539, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "年";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(477, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "周";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "天";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "小时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "秒";
            // 
            // tabSecondView1
            // 
            this.tabSecondView1.Location = new System.Drawing.Point(-1, 3);
            this.tabSecondView1.Name = "tabSecondView1";
            this.tabSecondView1.Size = new System.Drawing.Size(683, 284);
            this.tabSecondView1.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 399);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainView";
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabSecond.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSecond;
        private System.Windows.Forms.TabPage tabMins;
        private System.Windows.Forms.TabPage tabHour;
        private System.Windows.Forms.TabPage tabDay;
        private System.Windows.Forms.TabPage tabMonth;
        private System.Windows.Forms.TabPage tabWeek;
        private System.Windows.Forms.TabPage tabYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbWeek;
        private System.Windows.Forms.TextBox tbMonth;
        private System.Windows.Forms.TextBox tbDay;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.TextBox tbMins;
        private System.Windows.Forms.TextBox tbSecond;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Button btnRun;
        private UserViews.TabSecondView tabSecondView1;
    }
}

