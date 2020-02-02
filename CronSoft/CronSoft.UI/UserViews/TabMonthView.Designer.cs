namespace CronSoft.UI.UserViews
{
    partial class TabMonthView
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
            this.btnRadio_Month1 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Month2 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Month3 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Month4 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Month5 = new System.Windows.Forms.RadioButton();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.cb4 = new System.Windows.Forms.CheckBox();
            this.cb5 = new System.Windows.Forms.CheckBox();
            this.cb6 = new System.Windows.Forms.CheckBox();
            this.cb7 = new System.Windows.Forms.CheckBox();
            this.cb8 = new System.Windows.Forms.CheckBox();
            this.cb9 = new System.Windows.Forms.CheckBox();
            this.cb10 = new System.Windows.Forms.CheckBox();
            this.cb11 = new System.Windows.Forms.CheckBox();
            this.cb12 = new System.Windows.Forms.CheckBox();
            this.startMonth = new System.Windows.Forms.NumericUpDown();
            this.perMonth = new System.Windows.Forms.NumericUpDown();
            this.fromMonth = new System.Windows.Forms.NumericUpDown();
            this.toMonth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.startMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRadio_Month1
            // 
            this.btnRadio_Month1.AutoSize = true;
            this.btnRadio_Month1.Checked = true;
            this.btnRadio_Month1.Location = new System.Drawing.Point(3, 3);
            this.btnRadio_Month1.Name = "btnRadio_Month1";
            this.btnRadio_Month1.Size = new System.Drawing.Size(167, 16);
            this.btnRadio_Month1.TabIndex = 0;
            this.btnRadio_Month1.TabStop = true;
            this.btnRadio_Month1.Text = "月 允许的通配符[, - * /]";
            this.btnRadio_Month1.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Month2
            // 
            this.btnRadio_Month2.AutoSize = true;
            this.btnRadio_Month2.Location = new System.Drawing.Point(3, 25);
            this.btnRadio_Month2.Name = "btnRadio_Month2";
            this.btnRadio_Month2.Size = new System.Drawing.Size(59, 16);
            this.btnRadio_Month2.TabIndex = 1;
            this.btnRadio_Month2.Text = "不指定";
            this.btnRadio_Month2.UseVisualStyleBackColor = true;
            this.btnRadio_Month2.Click += new System.EventHandler(this.btnRadio_Month2_Click);
            // 
            // btnRadio_Month3
            // 
            this.btnRadio_Month3.AutoSize = true;
            this.btnRadio_Month3.Location = new System.Drawing.Point(3, 47);
            this.btnRadio_Month3.Name = "btnRadio_Month3";
            this.btnRadio_Month3.Size = new System.Drawing.Size(197, 16);
            this.btnRadio_Month3.TabIndex = 2;
            this.btnRadio_Month3.Text = "周期从          -          月";
            this.btnRadio_Month3.UseVisualStyleBackColor = true;
            this.btnRadio_Month3.Click += new System.EventHandler(this.btnRadio_Month3_Click);
            // 
            // btnRadio_Month4
            // 
            this.btnRadio_Month4.AutoSize = true;
            this.btnRadio_Month4.Location = new System.Drawing.Point(3, 69);
            this.btnRadio_Month4.Name = "btnRadio_Month4";
            this.btnRadio_Month4.Size = new System.Drawing.Size(275, 16);
            this.btnRadio_Month4.TabIndex = 3;
            this.btnRadio_Month4.Text = "从          日开始，每          月执行一次";
            this.btnRadio_Month4.UseVisualStyleBackColor = true;
            this.btnRadio_Month4.Click += new System.EventHandler(this.btnRadio_Month4_Click);
            // 
            // btnRadio_Month5
            // 
            this.btnRadio_Month5.AutoSize = true;
            this.btnRadio_Month5.Location = new System.Drawing.Point(3, 91);
            this.btnRadio_Month5.Name = "btnRadio_Month5";
            this.btnRadio_Month5.Size = new System.Drawing.Size(47, 16);
            this.btnRadio_Month5.TabIndex = 4;
            this.btnRadio_Month5.Text = "指定";
            this.btnRadio_Month5.UseVisualStyleBackColor = true;
            this.btnRadio_Month5.Click += new System.EventHandler(this.btnRadio_Month5_Click);
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(49, 113);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(30, 16);
            this.cb1.TabIndex = 5;
            this.cb1.Text = "1";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(85, 113);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(30, 16);
            this.cb2.TabIndex = 6;
            this.cb2.Text = "1";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Location = new System.Drawing.Point(121, 113);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(30, 16);
            this.cb3.TabIndex = 7;
            this.cb3.Text = "1";
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            this.cb4.AutoSize = true;
            this.cb4.Location = new System.Drawing.Point(157, 113);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(30, 16);
            this.cb4.TabIndex = 8;
            this.cb4.Text = "1";
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            this.cb5.AutoSize = true;
            this.cb5.Location = new System.Drawing.Point(193, 113);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(30, 16);
            this.cb5.TabIndex = 9;
            this.cb5.Text = "1";
            this.cb5.UseVisualStyleBackColor = true;
            // 
            // cb6
            // 
            this.cb6.AutoSize = true;
            this.cb6.Location = new System.Drawing.Point(229, 113);
            this.cb6.Name = "cb6";
            this.cb6.Size = new System.Drawing.Size(30, 16);
            this.cb6.TabIndex = 10;
            this.cb6.Text = "1";
            this.cb6.UseVisualStyleBackColor = true;
            // 
            // cb7
            // 
            this.cb7.AutoSize = true;
            this.cb7.Location = new System.Drawing.Point(265, 113);
            this.cb7.Name = "cb7";
            this.cb7.Size = new System.Drawing.Size(30, 16);
            this.cb7.TabIndex = 11;
            this.cb7.Text = "1";
            this.cb7.UseVisualStyleBackColor = true;
            // 
            // cb8
            // 
            this.cb8.AutoSize = true;
            this.cb8.Location = new System.Drawing.Point(301, 113);
            this.cb8.Name = "cb8";
            this.cb8.Size = new System.Drawing.Size(30, 16);
            this.cb8.TabIndex = 12;
            this.cb8.Text = "1";
            this.cb8.UseVisualStyleBackColor = true;
            // 
            // cb9
            // 
            this.cb9.AutoSize = true;
            this.cb9.Location = new System.Drawing.Point(337, 113);
            this.cb9.Name = "cb9";
            this.cb9.Size = new System.Drawing.Size(30, 16);
            this.cb9.TabIndex = 13;
            this.cb9.Text = "1";
            this.cb9.UseVisualStyleBackColor = true;
            // 
            // cb10
            // 
            this.cb10.AutoSize = true;
            this.cb10.Location = new System.Drawing.Point(373, 113);
            this.cb10.Name = "cb10";
            this.cb10.Size = new System.Drawing.Size(30, 16);
            this.cb10.TabIndex = 14;
            this.cb10.Text = "1";
            this.cb10.UseVisualStyleBackColor = true;
            // 
            // cb11
            // 
            this.cb11.AutoSize = true;
            this.cb11.Location = new System.Drawing.Point(409, 113);
            this.cb11.Name = "cb11";
            this.cb11.Size = new System.Drawing.Size(30, 16);
            this.cb11.TabIndex = 15;
            this.cb11.Text = "1";
            this.cb11.UseVisualStyleBackColor = true;
            // 
            // cb12
            // 
            this.cb12.AutoSize = true;
            this.cb12.Location = new System.Drawing.Point(445, 113);
            this.cb12.Name = "cb12";
            this.cb12.Size = new System.Drawing.Size(30, 16);
            this.cb12.TabIndex = 16;
            this.cb12.Text = "1";
            this.cb12.UseVisualStyleBackColor = true;
            // 
            // startMonth
            // 
            this.startMonth.Location = new System.Drawing.Point(43, 67);
            this.startMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.startMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startMonth.Name = "startMonth";
            this.startMonth.Size = new System.Drawing.Size(44, 21);
            this.startMonth.TabIndex = 43;
            this.startMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // perMonth
            // 
            this.perMonth.Location = new System.Drawing.Point(162, 67);
            this.perMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.perMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.perMonth.Name = "perMonth";
            this.perMonth.Size = new System.Drawing.Size(44, 21);
            this.perMonth.TabIndex = 44;
            this.perMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fromMonth
            // 
            this.fromMonth.Location = new System.Drawing.Point(64, 44);
            this.fromMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.fromMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fromMonth.Name = "fromMonth";
            this.fromMonth.Size = new System.Drawing.Size(44, 21);
            this.fromMonth.TabIndex = 45;
            this.fromMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toMonth
            // 
            this.toMonth.Location = new System.Drawing.Point(133, 44);
            this.toMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.toMonth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.toMonth.Name = "toMonth";
            this.toMonth.Size = new System.Drawing.Size(44, 21);
            this.toMonth.TabIndex = 46;
            this.toMonth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TabMonthView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toMonth);
            this.Controls.Add(this.fromMonth);
            this.Controls.Add(this.perMonth);
            this.Controls.Add(this.startMonth);
            this.Controls.Add(this.cb12);
            this.Controls.Add(this.cb11);
            this.Controls.Add(this.cb10);
            this.Controls.Add(this.cb9);
            this.Controls.Add(this.cb8);
            this.Controls.Add(this.cb7);
            this.Controls.Add(this.cb6);
            this.Controls.Add(this.cb5);
            this.Controls.Add(this.cb4);
            this.Controls.Add(this.cb3);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.btnRadio_Month5);
            this.Controls.Add(this.btnRadio_Month4);
            this.Controls.Add(this.btnRadio_Month3);
            this.Controls.Add(this.btnRadio_Month2);
            this.Controls.Add(this.btnRadio_Month1);
            this.Name = "TabMonthView";
            this.Size = new System.Drawing.Size(683, 284);
            this.Click += new System.EventHandler(this.TabMonthView_Click);
            ((System.ComponentModel.ISupportInitialize)(this.startMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnRadio_Month1;
        private System.Windows.Forms.RadioButton btnRadio_Month2;
        private System.Windows.Forms.RadioButton btnRadio_Month3;
        private System.Windows.Forms.RadioButton btnRadio_Month4;
        private System.Windows.Forms.RadioButton btnRadio_Month5;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.CheckBox cb2;
        private System.Windows.Forms.CheckBox cb3;
        private System.Windows.Forms.CheckBox cb4;
        private System.Windows.Forms.CheckBox cb5;
        private System.Windows.Forms.CheckBox cb6;
        private System.Windows.Forms.CheckBox cb7;
        private System.Windows.Forms.CheckBox cb8;
        private System.Windows.Forms.CheckBox cb9;
        private System.Windows.Forms.CheckBox cb10;
        private System.Windows.Forms.CheckBox cb11;
        private System.Windows.Forms.CheckBox cb12;
        private System.Windows.Forms.NumericUpDown startMonth;
        private System.Windows.Forms.NumericUpDown perMonth;
        private System.Windows.Forms.NumericUpDown fromMonth;
        private System.Windows.Forms.NumericUpDown toMonth;
    }
}
