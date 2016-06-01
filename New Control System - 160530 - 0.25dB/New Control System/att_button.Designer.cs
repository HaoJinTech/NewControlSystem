namespace New_Control_System
{
    partial class att_button
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
            this.textBox_edit_value = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ATT = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_edit_value
            // 
            this.textBox_edit_value.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox_edit_value.Location = new System.Drawing.Point(3, -3);
            this.textBox_edit_value.Multiline = true;
            this.textBox_edit_value.Name = "textBox_edit_value";
            this.textBox_edit_value.Size = new System.Drawing.Size(121, 88);
            this.textBox_edit_value.TabIndex = 4;
            this.textBox_edit_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_edit_value.TextChanged += new System.EventHandler(this.textBox_edit_value_TextChanged);
            this.textBox_edit_value.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_edit_value_KeyUp);
            this.textBox_edit_value.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_edit_value_PreviewKeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBox_edit_value);
            this.panel1.Controls.Add(this.label_ATT);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 82);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControl1_MouseClick);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label_ATT_MousseDoubleClick);
            // 
            // label_ATT
            // 
            this.label_ATT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ATT.BackColor = System.Drawing.Color.Transparent;
            this.label_ATT.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label_ATT.ForeColor = System.Drawing.Color.Black;
            this.label_ATT.Location = new System.Drawing.Point(3, 0);
            this.label_ATT.Name = "label_ATT";
            this.label_ATT.Size = new System.Drawing.Size(71, 37);
            this.label_ATT.TabIndex = 2;
            this.label_ATT.Text = "110.0";
            this.label_ATT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ATT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControl1_MouseClick);
            this.label_ATT.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label_ATT_MousseDoubleClick);
            // 
            // att_button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "att_button";
            this.Size = new System.Drawing.Size(124, 88);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.att_button_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserControl1_KeyUp);
            this.Resize += new System.EventHandler(this.att_button_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_edit_value;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label_ATT;
    }
}
