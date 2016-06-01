namespace New_Control_System
{
    partial class sweep_task
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_task_list = new System.Windows.Forms.Panel();
            this.lb_pot = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.n_times = new System.Windows.Forms.NumericUpDown();
            this.n_interval = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.n_step = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.n_end = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.n_start = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_out = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_in = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_task_name = new System.Windows.Forms.TextBox();
            this.timer_remove = new System.Windows.Forms.Timer(this.components);
            this.timer_run = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_task_list.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_step)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_start)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 438);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel_task_list);
            this.groupBox2.Location = new System.Drawing.Point(2, 121);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(845, 314);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task List";
            // 
            // panel_task_list
            // 
            this.panel_task_list.AutoScroll = true;
            this.panel_task_list.Controls.Add(this.lb_pot);
            this.panel_task_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_task_list.Location = new System.Drawing.Point(2, 15);
            this.panel_task_list.Name = "panel_task_list";
            this.panel_task_list.Size = new System.Drawing.Size(841, 297);
            this.panel_task_list.TabIndex = 0;
            // 
            // lb_pot
            // 
            this.lb_pot.AutoSize = true;
            this.lb_pot.Location = new System.Drawing.Point(5, 4);
            this.lb_pot.Name = "lb_pot";
            this.lb_pot.Size = new System.Drawing.Size(0, 13);
            this.lb_pot.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.n_times);
            this.groupBox1.Controls.Add(this.n_interval);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.n_step);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.n_end);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.n_start);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_out);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_in);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_task_name);
            this.groupBox1.Location = new System.Drawing.Point(2, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(846, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task Edit";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "label14";
            // 
            // n_times
            // 
            this.n_times.Location = new System.Drawing.Point(646, 28);
            this.n_times.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.n_times.Name = "n_times";
            this.n_times.Size = new System.Drawing.Size(45, 20);
            this.n_times.TabIndex = 26;
            this.n_times.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // n_interval
            // 
            this.n_interval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.n_interval.Location = new System.Drawing.Point(465, 28);
            this.n_interval.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.n_interval.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.n_interval.Name = "n_interval";
            this.n_interval.Size = new System.Drawing.Size(58, 20);
            this.n_interval.TabIndex = 25;
            this.n_interval.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.n_interval.ValueChanged += new System.EventHandler(this.n_interval_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(137)))), ((int)(((byte)(232)))));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(552, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "ADD NEW TASK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // n_step
            // 
            this.n_step.DecimalPlaces = 1;
            this.n_step.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.n_step.Location = new System.Drawing.Point(441, 68);
            this.n_step.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.n_step.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.n_step.Name = "n_step";
            this.n_step.Size = new System.Drawing.Size(50, 20);
            this.n_step.TabIndex = 24;
            this.n_step.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.n_step.ValueChanged += new System.EventHandler(this.n_step_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(533, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "ms/step";
            // 
            // n_end
            // 
            this.n_end.DecimalPlaces = 1;
            this.n_end.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.n_end.Location = new System.Drawing.Point(303, 69);
            this.n_end.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.n_end.Name = "n_end";
            this.n_end.Size = new System.Drawing.Size(58, 20);
            this.n_end.TabIndex = 23;
            this.n_end.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.n_end.ValueChanged += new System.EventHandler(this.n_end_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(366, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "dB";
            // 
            // n_start
            // 
            this.n_start.DecimalPlaces = 1;
            this.n_start.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.n_start.Location = new System.Drawing.Point(182, 69);
            this.n_start.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.n_start.Name = "n_start";
            this.n_start.Size = new System.Drawing.Size(46, 20);
            this.n_start.TabIndex = 22;
            this.n_start.ValueChanged += new System.EventHandler(this.n_start_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(270, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "end:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(233, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "dB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(140, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "start:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(81, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Range:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(399, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Step:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(596, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Times:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(406, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Interval:";
            // 
            // comboBox_out
            // 
            this.comboBox_out.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_out.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_out.FormattingEnabled = true;
            this.comboBox_out.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox_out.Location = new System.Drawing.Point(363, 26);
            this.comboBox_out.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_out.Name = "comboBox_out";
            this.comboBox_out.Size = new System.Drawing.Size(34, 25);
            this.comboBox_out.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(324, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "OUT:";
            // 
            // comboBox_in
            // 
            this.comboBox_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_in.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_in.FormattingEnabled = true;
            this.comboBox_in.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox_in.Location = new System.Drawing.Point(287, 26);
            this.comboBox_in.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_in.Name = "comboBox_in";
            this.comboBox_in.Size = new System.Drawing.Size(34, 25);
            this.comboBox_in.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(260, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "IN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(181, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task Name:";
            // 
            // textBox_task_name
            // 
            this.textBox_task_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_task_name.Location = new System.Drawing.Point(84, 26);
            this.textBox_task_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_task_name.Name = "textBox_task_name";
            this.textBox_task_name.Size = new System.Drawing.Size(93, 23);
            this.textBox_task_name.TabIndex = 0;
            this.textBox_task_name.Text = "Task 1";
            // 
            // timer_remove
            // 
            this.timer_remove.Interval = 10;
            this.timer_remove.Tick += new System.EventHandler(this.timer_remove_Tick);
            // 
            // timer_run
            // 
            this.timer_run.Interval = 50;
            this.timer_run.Tick += new System.EventHandler(this.timer_run_Tick);
            // 
            // sweep_task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "sweep_task";
            this.Size = new System.Drawing.Size(865, 455);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel_task_list.ResumeLayout(false);
            this.panel_task_list.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_step)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_out;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_in;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_task_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer_remove;
        public System.Windows.Forms.Timer timer_run;
        private System.Windows.Forms.NumericUpDown n_times;
        private System.Windows.Forms.NumericUpDown n_interval;
        private System.Windows.Forms.NumericUpDown n_step;
        private System.Windows.Forms.NumericUpDown n_end;
        private System.Windows.Forms.NumericUpDown n_start;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Panel panel_task_list;
        private System.Windows.Forms.Label lb_pot;
        public System.Windows.Forms.Button button1;
    }
}
