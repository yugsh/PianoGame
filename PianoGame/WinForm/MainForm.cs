using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midi;
using ControlExs;
using MidiSheetMusic;

namespace PianoGame
{
    public partial class MainForm : FormEx
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            SplashForm sf = new SplashForm();
            sf.ShowDialog();

            this.panel1.AutoScroll = true;
            this.panel1.HorizontalScroll.Enabled = true;
            this.panel1.VerticalScroll.Enabled = true;

            MidiFile midiFile = new MidiFile("E:/Mozart__Rondo_Alla_Turca.mid");
            MidiOptions options = new MidiOptions(midiFile);
            sheetMusic1.Load(midiFile, options);
            float zoom = (float)sheetMusic1.Width / SheetMusic.PageWidth;
            sheetMusic1.SetZoom(zoom);

            this.Opacity = 1;
        }

        private void Forward_Click(object sender, EventArgs e)
        {

        }

        private void Play_Click(object sender, EventArgs e)
        {

        }

        private void Backward_Click(object sender, EventArgs e)
        {

        }
    }
}
