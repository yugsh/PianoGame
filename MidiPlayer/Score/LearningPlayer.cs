using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midi
{
    class LearningPlayer
    {
        private InputDevice inputDevice;
        private MidiProcesser processer;
        private Pitch waitPitch;

        public event Action<Boolean, MidiEvent> LearningEvent;

        public LearningPlayer(InputDevice input, MidiFile midifile, MidiOptions midiOption)
        {
            processer = new MidiProcesser(midifile, midiOption);
            inputDevice = input;
            inputDevice.NoteOn += delegate(NoteOnMessage msg)
            {
                ProcessPitch(msg.Pitch);
            };

            processer.NoteOn += delegate(Channel channel, Pitch pitch, int velocity)
            {
                waitPitch = pitch;
                processer.Stop();
            };
        }

        public void StartPlayer()
        {
            if (inputDevice.IsOpen)
            {
                inputDevice.Open();
            }
        }


        /// <summary>
        /// 初略想法，等待弹奏事件，正确就继续，错误继续等待
        /// 同GamePlayer CurrentEvent 需要改造
        /// </summary>
        /// <param name="pitch"></param>
        private void ProcessPitch(Pitch pitch)
        {
            if (pitch == waitPitch)
            {
                processer.Continue();
                OnLearing(true, processer.CurrentEvent);
            }
            else
            {
                OnLearing(false, processer.CurrentEvent);
            }
        }

        protected virtual void OnLearing(Boolean right, MidiEvent ev)
        {
            Action<Boolean, MidiEvent> handler = LearningEvent;

            if (handler != null)
            {
                handler(right, ev);
            }
        }

    }
}
