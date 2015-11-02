using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlExs;

namespace PianoGame
{
    public partial class SplashForm : FormEx
    {
        private Timer timer1 = new Timer();
        public SplashForm()
        {
            InitializeComponent();
        }


        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.timer1.Interval = 3000; // 设置Timer的时间间隔  
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(Timer_Tick);
            this.timer1.Start(); // 开始Timer  
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
             this.timer1.Stop();
             this.Close();
        }  
    }
}
