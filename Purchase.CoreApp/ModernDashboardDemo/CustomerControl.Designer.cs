namespace ModernDashboardDemo
{
    partial class CustomerControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userAvatar = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.userSubTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // userAvatar
            // 
            this.userAvatar.Location = new System.Drawing.Point(3, 3);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(40, 37);
            this.userAvatar.TabIndex = 0;
            this.userAvatar.TabStop = false;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(50, 4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(87, 15);
            this.userName.TabIndex = 1;
            this.userName.Text = "User Manager";
            // 
            // userSubTitle
            // 
            this.userSubTitle.AutoSize = true;
            this.userSubTitle.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSubTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.userSubTitle.Location = new System.Drawing.Point(52, 22);
            this.userSubTitle.Name = "userSubTitle";
            this.userSubTitle.Size = new System.Drawing.Size(84, 16);
            this.userSubTitle.TabIndex = 1;
            this.userSubTitle.Text = "User Manager";
            // 
            // CustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userSubTitle);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userAvatar);
            this.Name = "CustomerControl";
            this.Size = new System.Drawing.Size(191, 46);
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userAvatar;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userSubTitle;
    }
}
