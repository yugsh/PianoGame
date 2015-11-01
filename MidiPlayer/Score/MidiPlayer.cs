using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace Midi
{
    public  class MidiPlayer
    {

        public enum MidiMode
        {
            MODE_GAME,
            MODE_APPRECIATE,
            MODE_LEARNING
        }

        private OutputDevice outDevice;
        private MidiProcesser processer;


        public MidiPlayer(MidiFile midiFile, MidiOptions midiOptions)
        {
            processer = new MidiProcesser(midiFile, midiOptions);

            processer.NoteOn += delegate(Channel channel, Pitch pitch, int velocity)
            {
                if (outDevice != null)
                {
                    outDevice.SendNoteOn(channel,pitch,velocity);
                }
            };

            processer.NoteOff += delegate(Channel channel, Pitch pitch, int velocity)
            {
                if (outDevice != null)
                {
                    outDevice.SendNoteOff(channel, pitch, velocity);
                }
            };

            processer.ProgramChange += delegate(Channel channel, Instrument instrument)
            {
                if (outDevice != null)
                {
                    outDevice.SendProgramChange(channel, instrument);
                }
            };

            processer.ControlChange += delegate(Channel channel, MidiControl control, int value)
            {
                if (outDevice != null)
                {
                    outDevice.SendControlChange(channel, control,value);
                }
            };
        }



        public void Start()
        {
            if (outDevice != null)
            {
                outDevice.Open();
            }
            processer.Start();
        }

        public void Seek(int position)
        {
            processer.Stop();
            processer.Position = position;
        }

        public void Pause()
        {
            processer.Stop();
        }

        public void Resume()
        {
            processer.Continue();
        }

        public void Stop()
        {
            if (outDevice != null)
            {
                outDevice.Close();
            }
            processer.Stop();
        }


        public OutputDevice OutDevice
        {
            get { return outDevice; }
            set { outDevice = value; }
        }
        
    }
}
