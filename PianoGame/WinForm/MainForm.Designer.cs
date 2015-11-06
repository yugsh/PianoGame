namespace PianoGame
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Backward = new ControlExs.ImageButton();
            this.Forward = new ControlExs.ImageButton();
            this.Play = new ControlExs.ImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sheetMusic1 = new MidiSheetMusic.SheetMusic();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Backward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Forward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Play)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Backward
            // 
            this.Backward.BackColor = System.Drawing.Color.Transparent;
            this.Backward.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Backward.DownImage = null;
            this.Backward.HoverImage = null;
            this.Backward.Location = new System.Drawing.Point(0, 48);
            this.Backward.Name = "Backward";
            this.Backward.NormalImage = null;
            this.Backward.Size = new System.Drawing.Size(75, 23);
            this.Backward.TabIndex = 1;
            this.Backward.TabStop = false;
            this.Backward.Text = "后退";
            this.Backward.ToolTipText = null;
            this.Backward.Click += new System.EventHandler(this.Backward_Click);
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.Color.Transparent;
            this.Forward.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Forward.DownImage = null;
            this.Forward.HoverImage = null;
            this.Forward.Location = new System.Drawing.Point(223, 48);
            this.Forward.Name = "Forward";
            this.Forward.NormalImage = null;
            this.Forward.Size = new System.Drawing.Size(75, 23);
            this.Forward.TabIndex = 3;
            this.Forward.TabStop = false;
            this.Forward.Text = "前进";
            this.Forward.ToolTipText = null;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.Transparent;
            this.Play.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Play.DownImage = null;
            this.Play.HoverImage = null;
            this.Play.Location = new System.Drawing.Point(113, 48);
            this.Play.Name = "Play";
            this.Play.NormalImage = null;
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 4;
            this.Play.TabStop = false;
            this.Play.Text = "开始";
            this.Play.ToolTipText = null;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sheetMusic1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 321);
            this.panel1.TabIndex = 5;
            // 
            // sheetMusic1
            // 
            this.sheetMusic1.Location = new System.Drawing.Point(0, 0);
            this.sheetMusic1.Name = "sheetMusic1";
            this.sheetMusic1.Size = new System.Drawing.Size(1280, 318);
            this.sheetMusic1.TabIndex = 0;
            this.sheetMusic1.Text = "sheetMusic1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.Backward);
            this.panel2.Controls.Add(this.Play);
            this.panel2.Controls.Add(this.Forward);
            this.panel2.Location = new System.Drawing.Point(307, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 120);
            this.panel2.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1041, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Backward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Forward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Play)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlExs.ImageButton Backward;
        private ControlExs.ImageButton Forward;
        private ControlExs.ImageButton Play;
        private System.Windows.Forms.Panel panel1;
        private MidiSheetMusic.SheetMusic sheetMusic1;
        private System.Windows.Forms.Panel panel2;


    }
}

