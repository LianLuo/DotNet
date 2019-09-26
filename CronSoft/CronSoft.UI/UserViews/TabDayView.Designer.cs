namespace CronSoft.UI.UserViews
{
    partial class TabDayView
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
            this.btnRadio_Day1 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day2 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day3 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day4 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day5 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day6 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Day7 = new System.Windows.Forms.RadioButton();
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
            this.cb13 = new System.Windows.Forms.CheckBox();
            this.cb14 = new System.Windows.Forms.CheckBox();
            this.cb15 = new System.Windows.Forms.CheckBox();
            this.cb16 = new System.Windows.Forms.CheckBox();
            this.cb31 = new System.Windows.Forms.CheckBox();
            this.cb30 = new System.Windows.Forms.CheckBox();
            this.cb29 = new System.Windows.Forms.CheckBox();
            this.cb28 = new System.Windows.Forms.CheckBox();
            this.cb27 = new System.Windows.Forms.CheckBox();
            this.cb26 = new System.Windows.Forms.CheckBox();
            this.cb25 = new System.Windows.Forms.CheckBox();
            this.cb24 = new System.Windows.Forms.CheckBox();
            this.cb23 = new System.Windows.Forms.CheckBox();
            this.cb22 = new System.Windows.Forms.CheckBox();
            this.cb21 = new System.Windows.Forms.CheckBox();
            this.cb20 = new System.Windows.Forms.CheckBox();
            this.cb19 = new System.Windows.Forms.CheckBox();
            this.cb18 = new System.Windows.Forms.CheckBox();
            this.cb17 = new System.Windows.Forms.CheckBox();
            this.fromDay = new System.Windows.Forms.NumericUpDown();
            this.toDay = new System.Windows.Forms.NumericUpDown();
            this.startDay = new System.Windows.Forms.NumericUpDown();
            this.perDay = new System.Windows.Forms.NumericUpDown();
            this.LastDay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.fromDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRadio_Day1
            // 
            this.btnRadio_Day1.AutoSize = true;
            this.btnRadio_Day1.Checked = true;
            this.btnRadio_Day1.Location = new System.Drawing.Point(3, 3);
            this.btnRadio_Day1.Name = "btnRadio_Day1";
            this.btnRadio_Day1.Size = new System.Drawing.Size(191, 16);
            this.btnRadio_Day1.TabIndex = 0;
            this.btnRadio_Day1.TabStop = true;
            this.btnRadio_Day1.Text = "日 允许的通配符[, - * / L W]";
            this.btnRadio_Day1.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day2
            // 
            this.btnRadio_Day2.AutoSize = true;
            this.btnRadio_Day2.Location = new System.Drawing.Point(3, 25);
            this.btnRadio_Day2.Name = "btnRadio_Day2";
            this.btnRadio_Day2.Size = new System.Drawing.Size(59, 16);
            this.btnRadio_Day2.TabIndex = 1;
            this.btnRadio_Day2.Text = "不指定";
            this.btnRadio_Day2.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day3
            // 
            this.btnRadio_Day3.AutoSize = true;
            this.btnRadio_Day3.Location = new System.Drawing.Point(3, 47);
            this.btnRadio_Day3.Name = "btnRadio_Day3";
            this.btnRadio_Day3.Size = new System.Drawing.Size(197, 16);
            this.btnRadio_Day3.TabIndex = 2;
            this.btnRadio_Day3.Text = "周期从          -          日";
            this.btnRadio_Day3.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day4
            // 
            this.btnRadio_Day4.AutoSize = true;
            this.btnRadio_Day4.Location = new System.Drawing.Point(3, 69);
            this.btnRadio_Day4.Name = "btnRadio_Day4";
            this.btnRadio_Day4.Size = new System.Drawing.Size(275, 16);
            this.btnRadio_Day4.TabIndex = 3;
            this.btnRadio_Day4.Text = "从          日开始，每          天执行一次";
            this.btnRadio_Day4.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day5
            // 
            this.btnRadio_Day5.AutoSize = true;
            this.btnRadio_Day5.Location = new System.Drawing.Point(4, 91);
            this.btnRadio_Day5.Name = "btnRadio_Day5";
            this.btnRadio_Day5.Size = new System.Drawing.Size(203, 16);
            this.btnRadio_Day5.TabIndex = 4;
            this.btnRadio_Day5.Text = "每个月          号最近的工作日";
            this.btnRadio_Day5.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day6
            // 
            this.btnRadio_Day6.AutoSize = true;
            this.btnRadio_Day6.Location = new System.Drawing.Point(3, 115);
            this.btnRadio_Day6.Name = "btnRadio_Day6";
            this.btnRadio_Day6.Size = new System.Drawing.Size(95, 16);
            this.btnRadio_Day6.TabIndex = 5;
            this.btnRadio_Day6.Text = "本月最后一天";
            this.btnRadio_Day6.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Day7
            // 
            this.btnRadio_Day7.AutoSize = true;
            this.btnRadio_Day7.Location = new System.Drawing.Point(3, 137);
            this.btnRadio_Day7.Name = "btnRadio_Day7";
            this.btnRadio_Day7.Size = new System.Drawing.Size(47, 16);
            this.btnRadio_Day7.TabIndex = 6;
            this.btnRadio_Day7.Text = "指定";
            this.btnRadio_Day7.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(47, 155);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(30, 16);
            this.cb1.TabIndex = 7;
            this.cb1.Text = "1";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(83, 155);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(30, 16);
            this.cb2.TabIndex = 8;
            this.cb2.Text = "1";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Location = new System.Drawing.Point(119, 155);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(30, 16);
            this.cb3.TabIndex = 9;
            this.cb3.Text = "1";
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            this.cb4.AutoSize = true;
            this.cb4.Location = new System.Drawing.Point(155, 155);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(30, 16);
            this.cb4.TabIndex = 10;
            this.cb4.Text = "1";
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            this.cb5.AutoSize = true;
            this.cb5.Location = new System.Drawing.Point(191, 155);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(30, 16);
            this.cb5.TabIndex = 11;
            this.cb5.Text = "1";
            this.cb5.UseVisualStyleBackColor = true;
            // 
            // cb6
            // 
            this.cb6.AutoSize = true;
            this.cb6.Location = new System.Drawing.Point(227, 155);
            this.cb6.Name = "cb6";
            this.cb6.Size = new System.Drawing.Size(30, 16);
            this.cb6.TabIndex = 12;
            this.cb6.Text = "1";
            this.cb6.UseVisualStyleBackColor = true;
            // 
            // cb7
            // 
            this.cb7.AutoSize = true;
            this.cb7.Location = new System.Drawing.Point(263, 155);
            this.cb7.Name = "cb7";
            this.cb7.Size = new System.Drawing.Size(30, 16);
            this.cb7.TabIndex = 13;
            this.cb7.Text = "1";
            this.cb7.UseVisualStyleBackColor = true;
            // 
            // cb8
            // 
            this.cb8.AutoSize = true;
            this.cb8.Location = new System.Drawing.Point(299, 155);
            this.cb8.Name = "cb8";
            this.cb8.Size = new System.Drawing.Size(30, 16);
            this.cb8.TabIndex = 14;
            this.cb8.Text = "1";
            this.cb8.UseVisualStyleBackColor = true;
            // 
            // cb9
            // 
            this.cb9.AutoSize = true;
            this.cb9.Location = new System.Drawing.Point(335, 155);
            this.cb9.Name = "cb9";
            this.cb9.Size = new System.Drawing.Size(30, 16);
            this.cb9.TabIndex = 15;
            this.cb9.Text = "1";
            this.cb9.UseVisualStyleBackColor = true;
            // 
            // cb10
            // 
            this.cb10.AutoSize = true;
            this.cb10.Location = new System.Drawing.Point(371, 155);
            this.cb10.Name = "cb10";
            this.cb10.Size = new System.Drawing.Size(30, 16);
            this.cb10.TabIndex = 16;
            this.cb10.Text = "1";
            this.cb10.UseVisualStyleBackColor = true;
            // 
            // cb11
            // 
            this.cb11.AutoSize = true;
            this.cb11.Location = new System.Drawing.Point(407, 155);
            this.cb11.Name = "cb11";
            this.cb11.Size = new System.Drawing.Size(30, 16);
            this.cb11.TabIndex = 17;
            this.cb11.Text = "1";
            this.cb11.UseVisualStyleBackColor = true;
            // 
            // cb12
            // 
            this.cb12.AutoSize = true;
            this.cb12.Location = new System.Drawing.Point(443, 155);
            this.cb12.Name = "cb12";
            this.cb12.Size = new System.Drawing.Size(30, 16);
            this.cb12.TabIndex = 18;
            this.cb12.Text = "1";
            this.cb12.UseVisualStyleBackColor = true;
            // 
            // cb13
            // 
            this.cb13.AutoSize = true;
            this.cb13.Location = new System.Drawing.Point(479, 155);
            this.cb13.Name = "cb13";
            this.cb13.Size = new System.Drawing.Size(30, 16);
            this.cb13.TabIndex = 19;
            this.cb13.Text = "1";
            this.cb13.UseVisualStyleBackColor = true;
            // 
            // cb14
            // 
            this.cb14.AutoSize = true;
            this.cb14.Location = new System.Drawing.Point(515, 155);
            this.cb14.Name = "cb14";
            this.cb14.Size = new System.Drawing.Size(30, 16);
            this.cb14.TabIndex = 20;
            this.cb14.Text = "1";
            this.cb14.UseVisualStyleBackColor = true;
            // 
            // cb15
            // 
            this.cb15.AutoSize = true;
            this.cb15.Location = new System.Drawing.Point(551, 155);
            this.cb15.Name = "cb15";
            this.cb15.Size = new System.Drawing.Size(30, 16);
            this.cb15.TabIndex = 21;
            this.cb15.Text = "1";
            this.cb15.UseVisualStyleBackColor = true;
            // 
            // cb16
            // 
            this.cb16.AutoSize = true;
            this.cb16.Location = new System.Drawing.Point(587, 155);
            this.cb16.Name = "cb16";
            this.cb16.Size = new System.Drawing.Size(30, 16);
            this.cb16.TabIndex = 22;
            this.cb16.Text = "1";
            this.cb16.UseVisualStyleBackColor = true;
            // 
            // cb31
            // 
            this.cb31.AutoSize = true;
            this.cb31.Location = new System.Drawing.Point(551, 177);
            this.cb31.Name = "cb31";
            this.cb31.Size = new System.Drawing.Size(30, 16);
            this.cb31.TabIndex = 37;
            this.cb31.Text = "1";
            this.cb31.UseVisualStyleBackColor = true;
            // 
            // cb30
            // 
            this.cb30.AutoSize = true;
            this.cb30.Location = new System.Drawing.Point(515, 177);
            this.cb30.Name = "cb30";
            this.cb30.Size = new System.Drawing.Size(30, 16);
            this.cb30.TabIndex = 36;
            this.cb30.Text = "1";
            this.cb30.UseVisualStyleBackColor = true;
            // 
            // cb29
            // 
            this.cb29.AutoSize = true;
            this.cb29.Location = new System.Drawing.Point(479, 177);
            this.cb29.Name = "cb29";
            this.cb29.Size = new System.Drawing.Size(30, 16);
            this.cb29.TabIndex = 35;
            this.cb29.Text = "1";
            this.cb29.UseVisualStyleBackColor = true;
            // 
            // cb28
            // 
            this.cb28.AutoSize = true;
            this.cb28.Location = new System.Drawing.Point(443, 177);
            this.cb28.Name = "cb28";
            this.cb28.Size = new System.Drawing.Size(30, 16);
            this.cb28.TabIndex = 34;
            this.cb28.Text = "1";
            this.cb28.UseVisualStyleBackColor = true;
            // 
            // cb27
            // 
            this.cb27.AutoSize = true;
            this.cb27.Location = new System.Drawing.Point(407, 177);
            this.cb27.Name = "cb27";
            this.cb27.Size = new System.Drawing.Size(30, 16);
            this.cb27.TabIndex = 33;
            this.cb27.Text = "1";
            this.cb27.UseVisualStyleBackColor = true;
            // 
            // cb26
            // 
            this.cb26.AutoSize = true;
            this.cb26.Location = new System.Drawing.Point(371, 177);
            this.cb26.Name = "cb26";
            this.cb26.Size = new System.Drawing.Size(30, 16);
            this.cb26.TabIndex = 32;
            this.cb26.Text = "1";
            this.cb26.UseVisualStyleBackColor = true;
            // 
            // cb25
            // 
            this.cb25.AutoSize = true;
            this.cb25.Location = new System.Drawing.Point(335, 177);
            this.cb25.Name = "cb25";
            this.cb25.Size = new System.Drawing.Size(30, 16);
            this.cb25.TabIndex = 31;
            this.cb25.Text = "1";
            this.cb25.UseVisualStyleBackColor = true;
            // 
            // cb24
            // 
            this.cb24.AutoSize = true;
            this.cb24.Location = new System.Drawing.Point(299, 177);
            this.cb24.Name = "cb24";
            this.cb24.Size = new System.Drawing.Size(30, 16);
            this.cb24.TabIndex = 30;
            this.cb24.Text = "1";
            this.cb24.UseVisualStyleBackColor = true;
            // 
            // cb23
            // 
            this.cb23.AutoSize = true;
            this.cb23.Location = new System.Drawing.Point(263, 177);
            this.cb23.Name = "cb23";
            this.cb23.Size = new System.Drawing.Size(30, 16);
            this.cb23.TabIndex = 29;
            this.cb23.Text = "1";
            this.cb23.UseVisualStyleBackColor = true;
            // 
            // cb22
            // 
            this.cb22.AutoSize = true;
            this.cb22.Location = new System.Drawing.Point(227, 177);
            this.cb22.Name = "cb22";
            this.cb22.Size = new System.Drawing.Size(30, 16);
            this.cb22.TabIndex = 28;
            this.cb22.Text = "1";
            this.cb22.UseVisualStyleBackColor = true;
            // 
            // cb21
            // 
            this.cb21.AutoSize = true;
            this.cb21.Location = new System.Drawing.Point(191, 177);
            this.cb21.Name = "cb21";
            this.cb21.Size = new System.Drawing.Size(30, 16);
            this.cb21.TabIndex = 27;
            this.cb21.Text = "1";
            this.cb21.UseVisualStyleBackColor = true;
            // 
            // cb20
            // 
            this.cb20.AutoSize = true;
            this.cb20.Location = new System.Drawing.Point(155, 177);
            this.cb20.Name = "cb20";
            this.cb20.Size = new System.Drawing.Size(30, 16);
            this.cb20.TabIndex = 26;
            this.cb20.Text = "1";
            this.cb20.UseVisualStyleBackColor = true;
            // 
            // cb19
            // 
            this.cb19.AutoSize = true;
            this.cb19.Location = new System.Drawing.Point(119, 177);
            this.cb19.Name = "cb19";
            this.cb19.Size = new System.Drawing.Size(30, 16);
            this.cb19.TabIndex = 25;
            this.cb19.Text = "1";
            this.cb19.UseVisualStyleBackColor = true;
            // 
            // cb18
            // 
            this.cb18.AutoSize = true;
            this.cb18.Location = new System.Drawing.Point(83, 177);
            this.cb18.Name = "cb18";
            this.cb18.Size = new System.Drawing.Size(30, 16);
            this.cb18.TabIndex = 24;
            this.cb18.Text = "1";
            this.cb18.UseVisualStyleBackColor = true;
            // 
            // cb17
            // 
            this.cb17.AutoSize = true;
            this.cb17.Location = new System.Drawing.Point(47, 177);
            this.cb17.Name = "cb17";
            this.cb17.Size = new System.Drawing.Size(30, 16);
            this.cb17.TabIndex = 23;
            this.cb17.Text = "1";
            this.cb17.UseVisualStyleBackColor = true;
            // 
            // fromDay
            // 
            this.fromDay.Location = new System.Drawing.Point(64, 42);
            this.fromDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.fromDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fromDay.Name = "fromDay";
            this.fromDay.Size = new System.Drawing.Size(44, 21);
            this.fromDay.TabIndex = 38;
            this.fromDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toDay
            // 
            this.toDay.Location = new System.Drawing.Point(127, 42);
            this.toDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.toDay.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.toDay.Name = "toDay";
            this.toDay.Size = new System.Drawing.Size(44, 21);
            this.toDay.TabIndex = 39;
            this.toDay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // startDay
            // 
            this.startDay.Location = new System.Drawing.Point(46, 66);
            this.startDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.startDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startDay.Name = "startDay";
            this.startDay.Size = new System.Drawing.Size(44, 21);
            this.startDay.TabIndex = 40;
            this.startDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // perDay
            // 
            this.perDay.Location = new System.Drawing.Point(163, 64);
            this.perDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.perDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.perDay.Name = "perDay";
            this.perDay.Size = new System.Drawing.Size(44, 21);
            this.perDay.TabIndex = 41;
            this.perDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LastDay
            // 
            this.LastDay.Location = new System.Drawing.Point(65, 88);
            this.LastDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.LastDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LastDay.Name = "LastDay";
            this.LastDay.Size = new System.Drawing.Size(44, 21);
            this.LastDay.TabIndex = 42;
            this.LastDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TabDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LastDay);
            this.Controls.Add(this.perDay);
            this.Controls.Add(this.startDay);
            this.Controls.Add(this.toDay);
            this.Controls.Add(this.fromDay);
            this.Controls.Add(this.cb31);
            this.Controls.Add(this.cb30);
            this.Controls.Add(this.cb29);
            this.Controls.Add(this.cb28);
            this.Controls.Add(this.cb27);
            this.Controls.Add(this.cb26);
            this.Controls.Add(this.cb25);
            this.Controls.Add(this.cb24);
            this.Controls.Add(this.cb23);
            this.Controls.Add(this.cb22);
            this.Controls.Add(this.cb21);
            this.Controls.Add(this.cb20);
            this.Controls.Add(this.cb19);
            this.Controls.Add(this.cb18);
            this.Controls.Add(this.cb17);
            this.Controls.Add(this.cb16);
            this.Controls.Add(this.cb15);
            this.Controls.Add(this.cb14);
            this.Controls.Add(this.cb13);
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
            this.Controls.Add(this.btnRadio_Day7);
            this.Controls.Add(this.btnRadio_Day6);
            this.Controls.Add(this.btnRadio_Day5);
            this.Controls.Add(this.btnRadio_Day4);
            this.Controls.Add(this.btnRadio_Day3);
            this.Controls.Add(this.btnRadio_Day2);
            this.Controls.Add(this.btnRadio_Day1);
            this.Name = "TabDayView";
            this.Size = new System.Drawing.Size(683, 284);
            ((System.ComponentModel.ISupportInitialize)(this.fromDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnRadio_Day1;
        private System.Windows.Forms.RadioButton btnRadio_Day2;
        private System.Windows.Forms.RadioButton btnRadio_Day3;
        private System.Windows.Forms.RadioButton btnRadio_Day4;
        private System.Windows.Forms.RadioButton btnRadio_Day5;
        private System.Windows.Forms.RadioButton btnRadio_Day6;
        private System.Windows.Forms.RadioButton btnRadio_Day7;
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
        private System.Windows.Forms.CheckBox cb13;
        private System.Windows.Forms.CheckBox cb14;
        private System.Windows.Forms.CheckBox cb15;
        private System.Windows.Forms.CheckBox cb16;
        private System.Windows.Forms.CheckBox cb31;
        private System.Windows.Forms.CheckBox cb30;
        private System.Windows.Forms.CheckBox cb29;
        private System.Windows.Forms.CheckBox cb28;
        private System.Windows.Forms.CheckBox cb27;
        private System.Windows.Forms.CheckBox cb26;
        private System.Windows.Forms.CheckBox cb25;
        private System.Windows.Forms.CheckBox cb24;
        private System.Windows.Forms.CheckBox cb23;
        private System.Windows.Forms.CheckBox cb22;
        private System.Windows.Forms.CheckBox cb21;
        private System.Windows.Forms.CheckBox cb20;
        private System.Windows.Forms.CheckBox cb19;
        private System.Windows.Forms.CheckBox cb18;
        private System.Windows.Forms.CheckBox cb17;
        private System.Windows.Forms.NumericUpDown fromDay;
        private System.Windows.Forms.NumericUpDown toDay;
        private System.Windows.Forms.NumericUpDown startDay;
        private System.Windows.Forms.NumericUpDown perDay;
        private System.Windows.Forms.NumericUpDown LastDay;
    }
}
