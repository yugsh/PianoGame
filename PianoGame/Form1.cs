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

namespace PianoGame
{
    public partial class Form1 : Form
    {
        private MessageDispatcher dispatcher;
        private OutputDevice device;

        public Form1()
        {
            InitializeComponent();
            runMidi();
        }

        public void runMidi()
        {
            device = OutputDevice.InstalledDevices[0];
            device.Open();


            MidiFile midiFile = new MidiFile("E:/173940.mid");
            MidiOptions options = new MidiOptions(midiFile);
            dispatcher = new MessageDispatcher();
            dispatcher.ChannelMessageDispatched += delegate(object sender, MidiEvent e)
            {
                if (e.EventFlag == MidiFile.EventNoteOn)
                {
                    device.SendNoteOn((Channel)e.Channel, (Pitch)e.Notenumber, e.Velocity);
                }
                else if (e.EventFlag == MidiFile.EventNoteOff)
                {
                    device.SendNoteOff((Channel)e.Channel, (Pitch)e.Notenumber, e.Velocity);
                }
                else if (e.EventFlag == MidiFile.EventProgramChange)
                {
                    device.SendProgramChange((Channel)e.Channel, (Instrument)e.Instrument);
                }
            };


            MidiPlayer player = new MidiPlayer(midiFile, options);
            player.Start();
            
        }
    }
}
