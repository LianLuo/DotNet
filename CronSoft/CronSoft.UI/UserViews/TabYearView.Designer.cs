namespace CronSoft.UI.UserViews
{
    partial class TabYearView
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
            this.btnRadio_Year1 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Year2 = new System.Windows.Forms.RadioButton();
            this.btnRadio_Year3 = new System.Windows.Forms.RadioButton();
            this.fromYear = new System.Windows.Forms.NumericUpDown();
            this.toYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.fromYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRadio_Year1
            // 
            this.btnRadio_Year1.AutoSize = true;
            this.btnRadio_Year1.Checked = true;
            this.btnRadio_Year1.Location = new System.Drawing.Point(3, 3);
            this.btnRadio_Year1.Name = "btnRadio_Year1";
            this.btnRadio_Year1.Size = new System.Drawing.Size(233, 16);
            this.btnRadio_Year1.TabIndex = 1;
            this.btnRadio_Year1.TabStop = true;
            this.btnRadio_Year1.Text = "不指定 允许的通配符[, - * /] 非必填";
            this.btnRadio_Year1.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Year2
            // 
            this.btnRadio_Year2.AutoSize = true;
            this.btnRadio_Year2.Location = new System.Drawing.Point(3, 25);
            this.btnRadio_Year2.Name = "btnRadio_Year2";
            this.btnRadio_Year2.Size = new System.Drawing.Size(47, 16);
            this.btnRadio_Year2.TabIndex = 2;
            this.btnRadio_Year2.Text = "每年";
            this.btnRadio_Year2.UseVisualStyleBackColor = true;
            // 
            // btnRadio_Year3
            // 
            this.btnRadio_Year3.AutoSize = true;
            this.btnRadio_Year3.Location = new System.Drawing.Point(3, 47);
            this.btnRadio_Year3.Name = "btnRadio_Year3";
            this.btnRadio_Year3.Size = new System.Drawing.Size(179, 16);
            this.btnRadio_Year3.TabIndex = 3;
            this.btnRadio_Year3.Text = "周期从           -        ";
            this.btnRadio_Year3.UseVisualStyleBackColor = true;
            // 
            // fromYear
            // 
            this.fromYear.Location = new System.Drawing.Point(62, 45);
            this.fromYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.fromYear.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.fromYear.Name = "fromYear";
            this.fromYear.Size = new System.Drawing.Size(54, 21);
            this.fromYear.TabIndex = 4;
            this.fromYear.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // toYear
            // 
            this.toYear.Location = new System.Drawing.Point(139, 44);
            this.toYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.toYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.toYear.Name = "toYear";
            this.toYear.Size = new System.Drawing.Size(54, 21);
            this.toYear.TabIndex = 5;
            this.toYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // TabYearView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toYear);
            this.Controls.Add(this.fromYear);
            this.Controls.Add(this.btnRadio_Year3);
            this.Controls.Add(this.btnRadio_Year2);
            this.Controls.Add(this.btnRadio_Year1);
            this.Name = "TabYearView";
            this.Size = new System.Drawing.Size(683, 284);
            ((System.ComponentModel.ISupportInitialize)(this.fromYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnRadio_Year1;
        private System.Windows.Forms.RadioButton btnRadio_Year2;
        private System.Windows.Forms.RadioButton btnRadio_Year3;
        private System.Windows.Forms.NumericUpDown fromYear;
        private System.Windows.Forms.NumericUpDown toYear;
    }
}
