namespace New_Control_System
{
    partial class Admin
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bt_koff = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.bt_re = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_ck = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "User 1: 192.168.127.254",
            "User 2: 192.168.127.254",
            "User 3: 192.168.127.254",
            "User 4: 192.168.127.254",
            "User 5: 192.168.127.254",
            "User 6: 192.168.127.254",
            "User 7: 192.168.127.254",
            "User 8: 192.168.127.254"});
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(167, 108);
            this.listBox1.TabIndex = 1;
            // 
            // bt_koff
            // 
            this.bt_koff.Location = new System.Drawing.Point(26, 188);
            this.bt_koff.Name = "bt_koff";
            this.bt_koff.Size = new System.Drawing.Size(124, 23);
            this.bt_koff.TabIndex = 2;
            this.bt_koff.Text = "Kick off";
            this.bt_koff.UseVisualStyleBackColor = true;
            this.bt_koff.Click += new System.EventHandler(this.bt_koff_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.bt_re);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.bt_ck);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.bt_koff);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 587);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User List";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Log Out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_re
            // 
            this.bt_re.Location = new System.Drawing.Point(26, 130);
            this.bt_re.Name = "bt_re";
            this.bt_re.Size = new System.Drawing.Size(124, 23);
            this.bt_re.TabIndex = 4;
            this.bt_re.Text = "Refresh";
            this.bt_re.UseVisualStyleBackColor = true;
            this.bt_re.Click += new System.EventHandler(this.bt_re_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "All Release";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_ck
            // 
            this.bt_ck.Location = new System.Drawing.Point(26, 159);
            this.bt_ck.Name = "bt_ck";
            this.bt_ck.Size = new System.Drawing.Size(124, 23);
            this.bt_ck.TabIndex = 3;
            this.bt_ck.Text = "Check";
            this.bt_ck.UseVisualStyleBackColor = true;
            this.bt_ck.Click += new System.EventHandler(this.bt_ck_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Default Value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(173, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(628, 587);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel View";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 568);
            this.panel1.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Admin";
            this.Size = new System.Drawing.Size(801, 587);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.SizeChanged += new System.EventHandler(this.Admin_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button bt_koff;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button bt_ck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button bt_re;
    }
}
