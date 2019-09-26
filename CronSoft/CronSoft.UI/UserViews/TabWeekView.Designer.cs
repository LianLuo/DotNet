namespace CronSoft.UI.UserViews
{
    partial class TabWeekView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRadio_Week1 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Week2 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Week3 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Week4 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Week5 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Week6 = new System.Windows.Forms.RadioButton();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numWeekend = new System.Windows.Forms.NumericUpDown();
            this.lastWeek = new System.Windows.Forms.NumericUpDown();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.cb4 = new System.Windows.Forms.CheckBox();
            this.cb5 = new System.Windows.Forms.CheckBox();
            this.cb6 = new System.Windows.Forms.CheckBox();
            this.cb7 = new System.Windows.Forms.CheckBox();
            this.cb8 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastWeek)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRadio_Week1
            // 
            this.btnRadio_Week1.AutoSize = true;
            this.btnRadio_Week1.Checked = true;
            this.btnRadio_Week1.Location = new System.Drawing.Point(3, 3);
            this.btnRadio_Week1.Name = "btnRadio_Week1";
            this.btnRadio_Week1.Size = new System.Drawing.Size(191, 16);
            this.btnRadio_Week1.TabIndex = 0;
            this.btnRadio_Week1.TabStop = true;
            this.btnRadio_Week1.Text = "周 允许的通配符[, - * / L #]";
            this.btnRadio_Week1.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Week2
            // 
            this.btnRadio_Week2.AutoSize = true;
            this.btnRadio_Week2.Location = new System.Drawing.Point(3, 25);
            this.btnRadio_Week2.Name = "btnRadio_Week2";
            this.btnRadio_Week2.Size = new System.Drawing.Size(59, 16);
            this.btnRadio_Week2.TabIndex = 1;
            this.btnRadio_Week2.TabStop = true;
            this.btnRadio_Week2.Text = "不指定";
            this.btnRadio_Week2.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Week3
            // 
            this.btnRadio_Week3.AutoSize = true;
            this.btnRadio_Week3.Location = new System.Drawing.Point(3, 47);
            this.btnRadio_Week3.Name = "btnRadio_Week3";
            this.btnRadio_Week3.Size = new System.Drawing.Size(89, 16);
            this.btnRadio_Week3.TabIndex = 2;
            this.btnRadio_Week3.TabStop = true;
            this.btnRadio_Week3.Text = "周期 从星期";
            this.btnRadio_Week3.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Week4
            // 
            this.btnRadio_Week4.AutoSize = true;
            this.btnRadio_Week4.Location = new System.Drawing.Point(3, 69);
            this.btnRadio_Week4.Name = "btnRadio_Week4";
            this.btnRadio_Week4.Size = new System.Drawing.Size(209, 16);
            this.btnRadio_Week4.TabIndex = 3;
            this.btnRadio_Week4.TabStop = true;
            this.btnRadio_Week4.Text = "第          周 的星期          ";
            this.btnRadio_Week4.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Week5
            // 
            this.btnRadio_Week5.AutoSize = true;
            this.btnRadio_Week5.Location = new System.Drawing.Point(3, 91);
            this.btnRadio_Week5.Name = "btnRadio_Week5";
            this.btnRadio_Week5.Size = new System.Drawing.Size(119, 16);
            this.btnRadio_Week5.TabIndex = 4;
            this.btnRadio_Week5.TabStop = true;
            this.btnRadio_Week5.Text = "本月最后一个星期";
            this.btnRadio_Week5.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Week6
            // 
            this.btnRadio_Week6.AutoSize = true;
            this.btnRadio_Week6.Location = new System.Drawing.Point(3, 113);
            this.btnRadio_Week6.Name = "btnRadio_Week6";
            this.btnRadio_Week6.Size = new System.Drawing.Size(47, 16);
            this.btnRadio_Week6.TabIndex = 5;
            this.btnRadio_Week6.TabStop = true;
            this.btnRadio_Week6.Text = "指定";
            this.btnRadio_Week6.UseVisualStyleBackColor = true;
            // 
            // numWeek
            // 
            this.numWeek.Location = new System.Drawing.Point(42, 67);
            this.numWeek.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(44, 21);
            this.numWeek.TabIndex = 43;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWeekend
            // 
            this.numWeekend.Location = new System.Drawing.Point(150, 67);
            this.numWeekend.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numWeekend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekend.Name = "numWeekend";
            this.numWeekend.Size = new System.Drawing.Size(44, 21);
            this.numWeekend.TabIndex = 44;
            this.numWeekend.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lastWeek
            // 
            this.lastWeek.Location = new System.Drawing.Point(126, 88);
            this.lastWeek.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.lastWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lastWeek.Name = "lastWeek";
            this.lastWeek.Size = new System.Drawing.Size(44, 21);
            this.lastWeek.TabIndex = 45;
            this.lastWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(44, 135);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(30, 16);
            this.cb1.TabIndex = 46;
            this.cb1.Text = "1";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(80, 135);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(30, 16);
            this.cb2.TabIndex = 47;
            this.cb2.Text = "1";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Location = new System.Drawing.Point(116, 135);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(30, 16);
            this.cb3.TabIndex = 48;
            this.cb3.Text = "1";
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            this.cb4.AutoSize = true;
            this.cb4.Location = new System.Drawing.Point(152, 135);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(30, 16);
            this.cb4.TabIndex = 49;
            this.cb4.Text = "1";
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            this.cb5.AutoSize = true;
            this.cb5.Location = new System.Drawing.Point(188, 135);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(30, 16);
            this.cb5.TabIndex = 50;
            this.cb5.Text = "1";
            this.cb5.UseVisualStyleBackColor = true;
            // 
            // cb6
            // 
            this.cb6.AutoSize = true;
            this.cb6.Location = new System.Drawing.Point(224, 135);
            this.cb6.Name = "cb6";
            this.cb6.Size = new System.Drawing.Size(30, 16);
            this.cb6.TabIndex = 51;
            this.cb6.Text = "1";
            this.cb6.UseVisualStyleBackColor = true;
            // 
            // cb7
            // 
            this.cb7.AutoSize = true;
            this.cb7.Location = new System.Drawing.Point(260, 135);
            this.cb7.Name = "cb7";
            this.cb7.Size = new System.Drawing.Size(30, 16);
            this.cb7.TabIndex = 52;
            this.cb7.Text = "1";
            this.cb7.UseVisualStyleBackColor = true;
            // 
            // cb8
            // 
            this.cb8.AutoSize = true;
            this.cb8.Location = new System.Drawing.Point(296, 135);
            this.cb8.Name = "cb8";
            this.cb8.Size = new System.Drawing.Size(30, 16);
            this.cb8.TabIndex = 53;
            this.cb8.Text = "1";
            this.cb8.UseVisualStyleBackColor = true;
            // 
            // TabWeekView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb8);
            this.Controls.Add(this.cb7);
            this.Controls.Add(this.cb6);
            this.Controls.Add(this.cb5);
            this.Controls.Add(this.cb4);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.lastWeek);
            this.Controls.Add(this.numWeekend);
            this.Controls.Add(this.numWeek);
            this.Controls.Add(this.btnRadio_Week6);
            this.Controls.Add(this.btnRadio_Week5);
            this.Controls.Add(this.btnRadio_Week4);
            this.Controls.Add(this.btnRadio_Week3);
            this.Controls.Add(this.btnRadio_Week2);
            this.Controls.Add(this.btnRadio_Week1);
            this.Name = "TabWeekView";
            this.Size = new System.Drawing.Size(683, 284);
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastWeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnRadio_Week1;
        private System.Windows.Forms.RadioButton btnRadio_Week2;
        private System.Windows.Forms.RadioButton btnRadio_Week3;
        private System.Windows.Forms.RadioButton btnRadio_Week4;
        private System.Windows.Forms.RadioButton btnRadio_Week5;
        private System.Windows.Forms.RadioButton btnRadio_Week6;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numWeekend;
        private System.Windows.Forms.NumericUpDown lastWeek;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.CheckBox cb2;
        private System.Windows.Forms.CheckBox cb3;
        private System.Windows.Forms.CheckBox cb4;
        private System.Windows.Forms.CheckBox cb5;
        private System.Windows.Forms.CheckBox cb6;
        private System.Windows.Forms.CheckBox cb7;
        private System.Windows.Forms.CheckBox cb8;
    }
}
