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

            this.panel1.BackColor = Color.Transparent;

            MidiFile midiFile = new MidiFile(Properties.Resources._173940, "173940");
            MidiOptions options = new MidiOptions(midiFile);
            sheetMusic1.Load(midiFile, options);

            this.Opacity = 1;
        }
    }
}
