namespace NDT_Learning_Demo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbRes = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chbo0 = new System.Windows.Forms.CheckBox();
            this.chbo7 = new System.Windows.Forms.CheckBox();
            this.chbo6 = new System.Windows.Forms.CheckBox();
            this.chbo5 = new System.Windows.Forms.CheckBox();
            this.chbo4 = new System.Windows.Forms.CheckBox();
            this.chbo3 = new System.Windows.Forms.CheckBox();
            this.chbo2 = new System.Windows.Forms.CheckBox();
            this.chbo1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnCollect = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 482);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPage1.Controls.Add(this.rtbRes);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 453);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Piano";
            // 
            // rtbRes
            // 
            this.rtbRes.Location = new System.Drawing.Point(33, 179);
            this.rtbRes.Name = "rtbRes";
            this.rtbRes.Size = new System.Drawing.Size(683, 214);
            this.rtbRes.TabIndex = 1;
            this.rtbRes.Text = "";
            this.rtbRes.WordWrap = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(33, 58);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 59);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.btnTrain);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.chbo0);
            this.tabPage2.Controls.Add(this.chbo7);
            this.tabPage2.Controls.Add(this.chbo6);
            this.tabPage2.Controls.Add(this.chbo5);
            this.tabPage2.Controls.Add(this.chbo4);
            this.tabPage2.Controls.Add(this.chbo3);
            this.tabPage2.Controls.Add(this.chbo2);
            this.tabPage2.Controls.Add(this.chbo1);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.rtbLog);
            this.tabPage2.Controls.Add(this.btnCollect);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 453);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Training";
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(602, 50);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 52);
            this.btnTrain.TabIndex = 12;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(45, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 50);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbo0
            // 
            this.chbo0.AutoSize = true;
            this.chbo0.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo0.Location = new System.Drawing.Point(540, 227);
            this.chbo0.Name = "chbo0";
            this.chbo0.Size = new System.Drawing.Size(70, 30);
            this.chbo0.TabIndex = 10;
            this.chbo0.Text = "null";
            this.chbo0.UseVisualStyleBackColor = true;
            this.chbo0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo0_MouseClick);
            // 
            // chbo7
            // 
            this.chbo7.AutoSize = true;
            this.chbo7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo7.Location = new System.Drawing.Point(489, 227);
            this.chbo7.Name = "chbo7";
            this.chbo7.Size = new System.Drawing.Size(51, 30);
            this.chbo7.TabIndex = 9;
            this.chbo7.Text = "xi";
            this.chbo7.UseVisualStyleBackColor = true;
            this.chbo7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo7_MouseClick);
            // 
            // chbo6
            // 
            this.chbo6.AutoSize = true;
            this.chbo6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo6.Location = new System.Drawing.Point(441, 227);
            this.chbo6.Name = "chbo6";
            this.chbo6.Size = new System.Drawing.Size(51, 30);
            this.chbo6.TabIndex = 8;
            this.chbo6.Text = "la";
            this.chbo6.UseVisualStyleBackColor = true;
            this.chbo6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo6_MouseClick);
            // 
            // chbo5
            // 
            this.chbo5.AutoSize = true;
            this.chbo5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo5.Location = new System.Drawing.Point(393, 227);
            this.chbo5.Name = "chbo5";
            this.chbo5.Size = new System.Drawing.Size(55, 30);
            this.chbo5.TabIndex = 7;
            this.chbo5.Text = "so";
            this.chbo5.UseVisualStyleBackColor = true;
            this.chbo5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo5_MouseClick);
            // 
            // chbo4
            // 
            this.chbo4.AutoSize = true;
            this.chbo4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo4.Location = new System.Drawing.Point(345, 227);
            this.chbo4.Name = "chbo4";
            this.chbo4.Size = new System.Drawing.Size(53, 30);
            this.chbo4.TabIndex = 6;
            this.chbo4.Text = "fa";
            this.chbo4.UseVisualStyleBackColor = true;
            this.chbo4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo4_MouseClick);
            // 
            // chbo3
            // 
            this.chbo3.AutoSize = true;
            this.chbo3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo3.Location = new System.Drawing.Point(297, 227);
            this.chbo3.Name = "chbo3";
            this.chbo3.Size = new System.Drawing.Size(59, 30);
            this.chbo3.TabIndex = 5;
            this.chbo3.Text = "mi";
            this.chbo3.UseVisualStyleBackColor = true;
            this.chbo3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo3_MouseClick);
            // 
            // chbo2
            // 
            this.chbo2.AutoSize = true;
            this.chbo2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo2.Location = new System.Drawing.Point(249, 227);
            this.chbo2.Name = "chbo2";
            this.chbo2.Size = new System.Drawing.Size(53, 30);
            this.chbo2.TabIndex = 4;
            this.chbo2.Text = "re";
            this.chbo2.UseVisualStyleBackColor = true;
            this.chbo2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo2_MouseClick);
            // 
            // chbo1
            // 
            this.chbo1.AutoSize = true;
            this.chbo1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbo1.Location = new System.Drawing.Point(201, 227);
            this.chbo1.Name = "chbo1";
            this.chbo1.Size = new System.Drawing.Size(59, 30);
            this.chbo1.TabIndex = 3;
            this.chbo1.Text = "do";
            this.chbo1.UseVisualStyleBackColor = true;
            this.chbo1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbo1_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(201, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 184);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(45, 303);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(660, 105);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            this.rtbLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbLog_KeyPress);
            // 
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(45, 50);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 52);
            this.btnCollect.TabIndex = 0;
            this.btnCollect.Text = "Collect";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnCollect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chbo7;
        private System.Windows.Forms.CheckBox chbo6;
        private System.Windows.Forms.CheckBox chbo5;
        private System.Windows.Forms.CheckBox chbo4;
        private System.Windows.Forms.CheckBox chbo3;
        private System.Windows.Forms.CheckBox chbo2;
        private System.Windows.Forms.CheckBox chbo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chbo0;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbRes;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTrain;
    }
}

