using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midi
{
    public class GamePlayer
    {
        //计分规则

        public enum State
        {
            MISSING = 0,
            NORMAL = 1,
            GOOD = 2,
            PERFECT =3
        }

        private InputDevice inputDevice;
        private MidiProcesser processer;

        public event Action<State, int,MidiEvent[]> PlayEvent;


        private int score;

        public GamePlayer(InputDevice input, MidiFile midifile, MidiOptions midiOption)
        {
            inputDevice = input;
            processer = new MidiProcesser(midifile, midiOption);

            inputDevice.NoteOn += delegate(NoteOnMessage msg)
            {
                ComputeScore(msg.Pitch, processer.Position);
            };

            inputDevice.NoteOff += delegate(NoteOffMessage msg)
            {
                   
            };

            inputDevice.ProgramChange += delegate(ProgramChangeMessage msg)
            {
                    
            };

            inputDevice.PitchBend += delegate(PitchBendMessage msg)
            {
                   
            };

        }

        public void StartPlayer()
        {
            if (!inputDevice.IsOpen)
            {
                inputDevice.Open();
            }

            processer.Continue();
        }

        /// <summary>
        /// 初略想法，离tick越近，得分越高，否则，得分越低
        /// CurrentEvent 需要改造成接下来要播放的同一个tick下所有事件
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="tick"></param>
        private void ComputeScore(Pitch pitch,int tick){

            bool isRight = false;
            State state = State.MISSING;
            MidiEvent[] current = processer.CurrentMidiEvent;

            Console.WriteLine("current.size:" + current.Length);
            foreach (MidiEvent ev in current)
            {
                Pitch currentPitch = (Pitch)ev.Notenumber;
                if (currentPitch == pitch)
                {
                    isRight = true;

                    int currentStart = ev.StartTime;
                    int currentEnd = currentStart + ev.DeltaTime;
                    if (currentEnd - tick < ev.DeltaTime / 4)
                    {
                        state = State.PERFECT;
                    }
                    else if (currentEnd - tick < ev.DeltaTime / 2)
                    {
                        state = State.GOOD;
                    }
                    else
                    {
                        state = State.NORMAL;
                    }
                }
            }

            if (!isRight)
            {
                state = State.MISSING;
            }
            score += Convert.ToInt32(state);
            OnPlaying(state, score, current);
        }

        protected virtual void OnPlaying(State state,int score, MidiEvent[] ev)
        {
            Action<State, int, MidiEvent[]> handler = PlayEvent;

            if (handler != null)
            {
                handler(state, score, ev);
            }
        }

    }
}
