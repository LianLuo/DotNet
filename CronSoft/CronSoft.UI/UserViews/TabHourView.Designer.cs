namespace CronSoft.UI.UserViews
{
    partial class TabHourView
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
            this.btnRadio_Hour1 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Hour2 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Hour3 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Hour4 = new System.Windows.Forms.RadioButton();
            this.fromHour = new System.Windows.Forms.NumericUpDown();
            this.toHour = new System.Windows.Forms.NumericUpDown();
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.perHour = new System.Windows.Forms.NumericUpDown();
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
            this.cb24 = new System.Windows.Forms.CheckBox();
            this.cb23 = new System.Windows.Forms.CheckBox();
            this.cb22 = new System.Windows.Forms.CheckBox();
            this.cb21 = new System.Windows.Forms.CheckBox();
            this.cb20 = new System.Windows.Forms.CheckBox();
            this.cb19 = new System.Windows.Forms.CheckBox();
            this.cb18 = new System.Windows.Forms.CheckBox();
            this.cb17 = new System.Windows.Forms.CheckBox();
            this.cb16 = new System.Windows.Forms.CheckBox();
            this.cb15 = new System.Windows.Forms.CheckBox();
            this.cb14 = new System.Windows.Forms.CheckBox();
            this.cb13 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fromHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perHour)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRadio_Hour1
            // 
            this.btnRadio_Hour1.AutoSize = true;
            this.btnRadio_Hour1.Checked = true;
            this.btnRadio_Hour1.Location = new System.Drawing.Point(3, 3);
            this.btnRadio_Hour1.Name = "btnRadio_Hour1";
            this.btnRadio_Hour1.Size = new System.Drawing.Size(179, 16);
            this.btnRadio_Hour1.TabIndex = 0;
            this.btnRadio_Hour1.TabStop = true;
            this.btnRadio_Hour1.Text = "小时 允许的通配符[, - * /]";
            this.btnRadio_Hour1.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Hour2
            // 
            this.btnRadio_Hour2.AutoSize = true;
            this.btnRadio_Hour2.Location = new System.Drawing.Point(3, 27);
            this.btnRadio_Hour2.Name = "btnRadio_Hour2";
            this.btnRadio_Hour2.Size = new System.Drawing.Size(215, 16);
            this.btnRadio_Hour2.TabIndex = 1;
            this.btnRadio_Hour2.Text = "周期从          -           小时";
            this.btnRadio_Hour2.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Hour3
            // 
            this.btnRadio_Hour3.AutoSize = true;
            this.btnRadio_Hour3.Location = new System.Drawing.Point(3, 51);
            this.btnRadio_Hour3.Name = "btnRadio_Hour3";
            this.btnRadio_Hour3.Size = new System.Drawing.Size(305, 16);
            this.btnRadio_Hour3.TabIndex = 2;
            this.btnRadio_Hour3.Text = "从           小时开始，每          小时执行一次";
            this.btnRadio_Hour3.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Hour4
            // 
            this.btnRadio_Hour4.AutoSize = true;
            this.btnRadio_Hour4.Location = new System.Drawing.Point(3, 77);
            this.btnRadio_Hour4.Name = "btnRadio_Hour4";
            this.btnRadio_Hour4.Size = new System.Drawing.Size(47, 16);
            this.btnRadio_Hour4.TabIndex = 3;
            this.btnRadio_Hour4.Text = "指定";
            this.btnRadio_Hour4.UseVisualStyleBackColor = true;
            // 
            // fromHour
            // 
            this.fromHour.Location = new System.Drawing.Point(59, 24);
            this.fromHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.fromHour.Name = "fromHour";
            this.fromHour.Size = new System.Drawing.Size(48, 21);
            this.fromHour.TabIndex = 4;
            // 
            // toHour
            // 
            this.toHour.Location = new System.Drawing.Point(131, 24);
            this.toHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.toHour.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.toHour.Name = "toHour";
            this.toHour.Size = new System.Drawing.Size(48, 21);
            this.toHour.TabIndex = 5;
            this.toHour.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // startHour
            // 
            this.startHour.Location = new System.Drawing.Point(41, 50);
            this.startHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(48, 21);
            this.startHour.TabIndex = 6;
            // 
            // perHour
            // 
            this.perHour.Location = new System.Drawing.Point(177, 49);
            this.perHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.perHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.perHour.Name = "perHour";
            this.perHour.Size = new System.Drawing.Size(48, 21);
            this.perHour.TabIndex = 7;
            this.perHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(47, 100);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(36, 16);
            this.cb1.TabIndex = 8;
            this.cb1.Text = "00";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(89, 100);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(36, 16);
            this.cb2.TabIndex = 9;
            this.cb2.Text = "00";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Location = new System.Drawing.Point(131, 100);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(36, 16);
            this.cb3.TabIndex = 10;
            this.cb3.Text = "00";
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            this.cb4.AutoSize = true;
            this.cb4.Location = new System.Drawing.Point(173, 100);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(36, 16);
            this.cb4.TabIndex = 11;
            this.cb4.Text = "00";
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            this.cb5.AutoSize = true;
            this.cb5.Location = new System.Drawing.Point(215, 100);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(36, 16);
            this.cb5.TabIndex = 12;
            this.cb5.Text = "00";
            this.cb5.UseVisualStyleBackColor = true;
            // 
            // cb6
            // 
            this.cb6.AutoSize = true;
            this.cb6.Location = new System.Drawing.Point(257, 100);
            this.cb6.Name = "cb6";
            this.cb6.Size = new System.Drawing.Size(36, 16);
            this.cb6.TabIndex = 13;
            this.cb6.Text = "00";
            this.cb6.UseVisualStyleBackColor = true;
            // 
            // cb7
            // 
            this.cb7.AutoSize = true;
            this.cb7.Location = new System.Drawing.Point(299, 100);
            this.cb7.Name = "cb7";
            this.cb7.Size = new System.Drawing.Size(36, 16);
            this.cb7.TabIndex = 14;
            this.cb7.Text = "00";
            this.cb7.UseVisualStyleBackColor = true;
            // 
            // cb8
            // 
            this.cb8.AutoSize = true;
            this.cb8.Location = new System.Drawing.Point(341, 100);
            this.cb8.Name = "cb8";
            this.cb8.Size = new System.Drawing.Size(36, 16);
            this.cb8.TabIndex = 15;
            this.cb8.Text = "00";
            this.cb8.UseVisualStyleBackColor = true;
            // 
            // cb9
            // 
            this.cb9.AutoSize = true;
            this.cb9.Location = new System.Drawing.Point(383, 100);
            this.cb9.Name = "cb9";
            this.cb9.Size = new System.Drawing.Size(36, 16);
            this.cb9.TabIndex = 16;
            this.cb9.Text = "00";
            this.cb9.UseVisualStyleBackColor = true;
            // 
            // cb10
            // 
            this.cb10.AutoSize = true;
            this.cb10.Location = new System.Drawing.Point(425, 100);
            this.cb10.Name = "cb10";
            this.cb10.Size = new System.Drawing.Size(36, 16);
            this.cb10.TabIndex = 17;
            this.cb10.Text = "00";
            this.cb10.UseVisualStyleBackColor = true;
            // 
            // cb11
            // 
            this.cb11.AutoSize = true;
            this.cb11.Location = new System.Drawing.Point(467, 100);
            this.cb11.Name = "cb11";
            this.cb11.Size = new System.Drawing.Size(36, 16);
            this.cb11.TabIndex = 18;
            this.cb11.Text = "00";
            this.cb11.UseVisualStyleBackColor = true;
            // 
            // cb12
            // 
            this.cb12.AutoSize = true;
            this.cb12.Location = new System.Drawing.Point(509, 100);
            this.cb12.Name = "cb12";
            this.cb12.Size = new System.Drawing.Size(36, 16);
            this.cb12.TabIndex = 19;
            this.cb12.Text = "00";
            this.cb12.UseVisualStyleBackColor = true;
            // 
            // cb24
            // 
            this.cb24.AutoSize = true;
            this.cb24.Location = new System.Drawing.Point(509, 122);
            this.cb24.Name = "cb24";
            this.cb24.Size = new System.Drawing.Size(36, 16);
            this.cb24.TabIndex = 31;
            this.cb24.Text = "00";
            this.cb24.UseVisualStyleBackColor = true;
            // 
            // cb23
            // 
            this.cb23.AutoSize = true;
            this.cb23.Location = new System.Drawing.Point(467, 122);
            this.cb23.Name = "cb23";
            this.cb23.Size = new System.Drawing.Size(36, 16);
            this.cb23.TabIndex = 30;
            this.cb23.Text = "00";
            this.cb23.UseVisualStyleBackColor = true;
            // 
            // cb22
            // 
            this.cb22.AutoSize = true;
            this.cb22.Location = new System.Drawing.Point(425, 122);
            this.cb22.Name = "cb22";
            this.cb22.Size = new System.Drawing.Size(36, 16);
            this.cb22.TabIndex = 29;
            this.cb22.Text = "00";
            this.cb22.UseVisualStyleBackColor = true;
            // 
            // cb21
            // 
            this.cb21.AutoSize = true;
            this.cb21.Location = new System.Drawing.Point(383, 122);
            this.cb21.Name = "cb21";
            this.cb21.Size = new System.Drawing.Size(36, 16);
            this.cb21.TabIndex = 28;
            this.cb21.Text = "00";
            this.cb21.UseVisualStyleBackColor = true;
            // 
            // cb20
            // 
            this.cb20.AutoSize = true;
            this.cb20.Location = new System.Drawing.Point(341, 122);
            this.cb20.Name = "cb20";
            this.cb20.Size = new System.Drawing.Size(36, 16);
            this.cb20.TabIndex = 27;
            this.cb20.Text = "00";
            this.cb20.UseVisualStyleBackColor = true;
            // 
            // cb19
            // 
            this.cb19.AutoSize = true;
            this.cb19.Location = new System.Drawing.Point(299, 122);
            this.cb19.Name = "cb19";
            this.cb19.Size = new System.Drawing.Size(36, 16);
            this.cb19.TabIndex = 26;
            this.cb19.Text = "00";
            this.cb19.UseVisualStyleBackColor = true;
            // 
            // cb18
            // 
            this.cb18.AutoSize = true;
            this.cb18.Location = new System.Drawing.Point(257, 122);
            this.cb18.Name = "cb18";
            this.cb18.Size = new System.Drawing.Size(36, 16);
            this.cb18.TabIndex = 25;
            this.cb18.Text = "00";
            this.cb18.UseVisualStyleBackColor = true;
            // 
            // cb17
            // 
            this.cb17.AutoSize = true;
            this.cb17.Location = new System.Drawing.Point(215, 122);
            this.cb17.Name = "cb17";
            this.cb17.Size = new System.Drawing.Size(36, 16);
            this.cb17.TabIndex = 24;
            this.cb17.Text = "00";
            this.cb17.UseVisualStyleBackColor = true;
            // 
            // cb16
            // 
            this.cb16.AutoSize = true;
            this.cb16.Location = new System.Drawing.Point(173, 122);
            this.cb16.Name = "cb16";
            this.cb16.Size = new System.Drawing.Size(36, 16);
            this.cb16.TabIndex = 23;
            this.cb16.Text = "00";
            this.cb16.UseVisualStyleBackColor = true;
            // 
            // cb15
            // 
            this.cb15.AutoSize = true;
            this.cb15.Location = new System.Drawing.Point(131, 122);
            this.cb15.Name = "cb15";
            this.cb15.Size = new System.Drawing.Size(36, 16);
            this.cb15.TabIndex = 22;
            this.cb15.Text = "00";
            this.cb15.UseVisualStyleBackColor = true;
            // 
            // cb14
            // 
            this.cb14.AutoSize = true;
            this.cb14.Location = new System.Drawing.Point(89, 122);
            this.cb14.Name = "cb14";
            this.cb14.Size = new System.Drawing.Size(36, 16);
            this.cb14.TabIndex = 21;
            this.cb14.Text = "00";
            this.cb14.UseVisualStyleBackColor = true;
            // 
            // cb13
            // 
            this.cb13.AutoSize = true;
            this.cb13.Location = new System.Drawing.Point(47, 122);
            this.cb13.Name = "cb13";
            this.cb13.Size = new System.Drawing.Size(36, 16);
            this.cb13.TabIndex = 20;
            this.cb13.Text = "00";
            this.cb13.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "AM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "PM:";
            // 
            // TabHourView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.perHour);
            this.Controls.Add(this.startHour);
            this.Controls.Add(this.toHour);
            this.Controls.Add(this.fromHour);
            this.Controls.Add(this.btnRadio_Hour4);
            this.Controls.Add(this.btnRadio_Hour3);
            this.Controls.Add(this.btnRadio_Hour2);
            this.Controls.Add(this.btnRadio_Hour1);
            this.Name = "TabHourView";
            this.Size = new System.Drawing.Size(683, 284);
            ((System.ComponentModel.ISupportInitialize)(this.fromHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnRadio_Hour1;
        private System.Windows.Forms.RadioButton btnRadio_Hour2;
        private System.Windows.Forms.RadioButton btnRadio_Hour3;
        private System.Windows.Forms.RadioButton btnRadio_Hour4;
        private System.Windows.Forms.NumericUpDown fromHour;
        private System.Windows.Forms.NumericUpDown toHour;
        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.NumericUpDown perHour;
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
        private System.Windows.Forms.CheckBox cb24;
        private System.Windows.Forms.CheckBox cb23;
        private System.Windows.Forms.CheckBox cb22;
        private System.Windows.Forms.CheckBox cb21;
        private System.Windows.Forms.CheckBox cb20;
        private System.Windows.Forms.CheckBox cb19;
        private System.Windows.Forms.CheckBox cb18;
        private System.Windows.Forms.CheckBox cb17;
        private System.Windows.Forms.CheckBox cb16;
        private System.Windows.Forms.CheckBox cb15;
        private System.Windows.Forms.CheckBox cb14;
        private System.Windows.Forms.CheckBox cb13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
