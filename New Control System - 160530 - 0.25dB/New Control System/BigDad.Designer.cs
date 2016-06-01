namespace New_Control_System
{
    partial class BigDad
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
            this.p1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_l1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_l2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_t = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(0, 0);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(764, 462);
            this.p1.TabIndex = 9;
            this.p1.Paint += new System.Windows.Forms.PaintEventHandler(this.p1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.st_l1,
            this.st_l2,
            this.st_t});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel1.Text = "Device";
            // 
            // st_l1
            // 
            this.st_l1.AutoSize = false;
            this.st_l1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.st_l1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.st_l1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.st_l1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.st_l1.Name = "st_l1";
            this.st_l1.Size = new System.Drawing.Size(65, 17);
            // 
            // st_l2
            // 
            this.st_l2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.st_l2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.st_l2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.st_l2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.st_l2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.st_l2.Name = "st_l2";
            this.st_l2.Size = new System.Drawing.Size(476, 17);
            this.st_l2.Spring = true;
            this.st_l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_l2.TextChanged += new System.EventHandler(this.st_l2_TextChanged);
            // 
            // st_t
            // 
            this.st_t.AutoSize = false;
            this.st_t.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.st_t.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.st_t.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.st_t.Name = "st_t";
            this.st_t.Size = new System.Drawing.Size(60, 17);
            // 
            // BigDad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.p1);
            this.Name = "BigDad";
            this.Size = new System.Drawing.Size(766, 486);
            this.Load += new System.EventHandler(this.BigDad_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel p1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel st_l1;
        public System.Windows.Forms.ToolStripStatusLabel st_l2;
        public System.Windows.Forms.ToolStripStatusLabel st_t;
    }
}
