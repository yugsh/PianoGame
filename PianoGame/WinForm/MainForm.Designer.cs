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
            this.imageButton1 = new ControlExs.ImageButton();
            this.imageButton2 = new ControlExs.ImageButton();
            this.imageButton3 = new ControlExs.ImageButton();
            this.imageButton4 = new ControlExs.ImageButton();
            this.imageButton5 = new ControlExs.ImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sheetMusic1 = new MidiSheetMusic.SheetMusic();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButton1.DownImage = null;
            this.imageButton1.HoverImage = null;
            this.imageButton1.Location = new System.Drawing.Point(471, 354);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.NormalImage = null;
            this.imageButton1.Size = new System.Drawing.Size(75, 23);
            this.imageButton1.TabIndex = 0;
            this.imageButton1.TabStop = false;
            this.imageButton1.Text = "imageButton1";
            this.imageButton1.ToolTipText = null;
            // 
            // imageButton2
            // 
            this.imageButton2.BackColor = System.Drawing.Color.Transparent;
            this.imageButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButton2.DownImage = null;
            this.imageButton2.HoverImage = null;
            this.imageButton2.Location = new System.Drawing.Point(377, 394);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.NormalImage = null;
            this.imageButton2.Size = new System.Drawing.Size(75, 23);
            this.imageButton2.TabIndex = 1;
            this.imageButton2.TabStop = false;
            this.imageButton2.Text = "imageButton2";
            this.imageButton2.ToolTipText = null;
            // 
            // imageButton3
            // 
            this.imageButton3.BackColor = System.Drawing.Color.Transparent;
            this.imageButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButton3.DownImage = null;
            this.imageButton3.HoverImage = null;
            this.imageButton3.Location = new System.Drawing.Point(471, 437);
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.NormalImage = null;
            this.imageButton3.Size = new System.Drawing.Size(75, 23);
            this.imageButton3.TabIndex = 2;
            this.imageButton3.TabStop = false;
            this.imageButton3.Text = "imageButton3";
            this.imageButton3.ToolTipText = null;
            // 
            // imageButton4
            // 
            this.imageButton4.BackColor = System.Drawing.Color.Transparent;
            this.imageButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButton4.DownImage = null;
            this.imageButton4.HoverImage = null;
            this.imageButton4.Location = new System.Drawing.Point(570, 394);
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.NormalImage = null;
            this.imageButton4.Size = new System.Drawing.Size(75, 23);
            this.imageButton4.TabIndex = 3;
            this.imageButton4.TabStop = false;
            this.imageButton4.Text = "imageButton4";
            this.imageButton4.ToolTipText = null;
            // 
            // imageButton5
            // 
            this.imageButton5.BackColor = System.Drawing.Color.Transparent;
            this.imageButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButton5.DownImage = null;
            this.imageButton5.HoverImage = null;
            this.imageButton5.Location = new System.Drawing.Point(471, 394);
            this.imageButton5.Name = "imageButton5";
            this.imageButton5.NormalImage = null;
            this.imageButton5.Size = new System.Drawing.Size(75, 23);
            this.imageButton5.TabIndex = 4;
            this.imageButton5.TabStop = false;
            this.imageButton5.Text = "imageButton5";
            this.imageButton5.ToolTipText = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sheetMusic1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 321);
            this.panel1.TabIndex = 5;
            // 
            // sheetMusic1
            // 
            this.sheetMusic1.Location = new System.Drawing.Point(0, 0);
            this.sheetMusic1.Name = "sheetMusic1";
            this.sheetMusic1.Size = new System.Drawing.Size(1017, 318);
            this.sheetMusic1.TabIndex = 0;
            this.sheetMusic1.Text = "sheetMusic1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1041, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imageButton5);
            this.Controls.Add(this.imageButton4);
            this.Controls.Add(this.imageButton3);
            this.Controls.Add(this.imageButton2);
            this.Controls.Add(this.imageButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlExs.ImageButton imageButton1;
        private ControlExs.ImageButton imageButton2;
        private ControlExs.ImageButton imageButton3;
        private ControlExs.ImageButton imageButton4;
        private ControlExs.ImageButton imageButton5;
        private System.Windows.Forms.Panel panel1;
        private MidiSheetMusic.SheetMusic sheetMusic1;


    }
}

