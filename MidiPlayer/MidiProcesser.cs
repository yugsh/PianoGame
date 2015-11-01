using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace Midi
{
    public class MidiProcesser
    {
        private MidiInternalClock clock = new MidiInternalClock();
        private bool playing = false;
        private bool disposed = false;
        private readonly object lockObject = new object();

        private int tracksPlayingCount;
        private MidiFile mMidiFile;
        private MidiOptions mMidiOptions;
        private List<IEnumerator<MidiEvent>> enumerators = new List<IEnumerator<MidiEvent>>();
        private MidiEvent currentEvent;


        private MessageDispatcher dispatcher = new MessageDispatcher();

        public event EventHandler PlayingCompleted;

        public event Action<Channel, Pitch,int> NoteOn;
        public event Action<Channel, Pitch, int> NoteOff;
        public event Action<Channel, Instrument> ProgramChange;
        public event Action<Channel, MidiControl, int> ControlChange;

        public MessageDispatcher Dispatcher
        {
            get 
            { 
                return dispatcher; 
            }
        }

        public int Position
        {
            get
            {
                #region Require

                if (disposed)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }

                #endregion

                return clock.Ticks;
            }
            set
            {
                #region Require

                if (disposed)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                #endregion

                bool wasPlaying;

                lock (lockObject)
                {
                    wasPlaying = playing;

                    Stop();

                    clock.SetTicks(value);
                }

                lock (lockObject)
                {
                    if (wasPlaying)
                    {
                        Continue();
                    }
                }
            }
        }

        public MidiEvent CurrentEvent
        {
            get { return currentEvent; }
        }

        public MidiProcesser(MidiFile midiFile, MidiOptions midiOptions)
        {
            mMidiFile = midiFile;
            mMidiOptions = midiOptions;
            tracksPlayingCount = midiFile.Events.Length;

            //Tick事件
            clock.Tick += delegate(object sender, EventArgs e)
            {
                foreach (IEnumerator<MidiEvent> enumerator in enumerators)
                {
                    ProcessTracks(enumerator);
                }
            };

            //Channel事件处理
            dispatcher.ChannelMessageDispatched += delegate(object sender, MidiEvent e)
            {
                if (e.EventFlag == MidiFile.EventNoteOn)
                {
                    OnNoteOn((Channel)e.Channel, (Pitch)e.Notenumber, e.Velocity);
                    currentEvent = e;
                }
                else if (e.EventFlag == MidiFile.EventNoteOff)
                {
                    OnNoteOff((Channel)e.Channel, (Pitch)e.Notenumber, e.Velocity);
                }
                else if (e.EventFlag == MidiFile.EventProgramChange)
                {
                    OnProgramChange((Channel)e.Channel, (Instrument)e.Instrument);
                }
                else if (e.EventFlag == MidiFile.EventControlChange)
                {
                    OnControlChange((Channel)e.Channel, (MidiControl)e.ControlNum, e.ControlValue);
                }
            };

            //Meta 事件处理
            dispatcher.MetaMessageDispatched += delegate(object sender, MidiEvent e)
            {

                if (e.Metaevent == MidiFile.MetaEventTempo)
                {
                    clock.Tempo = e.Tempo;
                }
                else if (e.Metaevent == MidiFile.MetaEventEndOfTrack)
                {
                    tracksPlayingCount--;
                    if (tracksPlayingCount == 0)
                    {
                        Stop();

                        OnPlayingCompleted(EventArgs.Empty);
                    }
                }
            };

            //节拍器
            clock.Metronome += delegate(object sender, EventArgs e)
            {
                Console.WriteLine("Metronome ... tick:"+clock.Ticks);
            };
        }

        private void ProcessTracks(IEnumerator<MidiEvent> enumerator)
        {
            bool notFinished = true;
            if (enumerator.Current == null)
            {
                notFinished = enumerator.MoveNext();
            }

            while (notFinished && enumerator.Current.StartTime < Position)
            {
                if (enumerator.Current.Type == MessageType.Channel)
                {
                    dispatcher.Chase(enumerator.Current);
                }
                else if (enumerator.Current.Type == MessageType.Meta)
                {
                    dispatcher.Dispatch(enumerator.Current);
                }
                notFinished = enumerator.MoveNext();
            }

            int tick = clock.Ticks;

            if (notFinished && tick < enumerator.Current.StartTime)
            {
                return;
            }

            while (notFinished && enumerator.Current.StartTime == tick)
            {
                dispatcher.Dispatch(enumerator.Current);

                notFinished = enumerator.MoveNext();
            }


        }

        public void Start()
        {
            #region Require

            if (disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }

            #endregion

            lock (lockObject)
            {
                Stop();

                Continue();
            }
        }



        public void Continue()
        {
            enumerators.Clear();
            foreach (List<MidiEvent> track in mMidiFile.Events)
            {
                if (track != null && track.Count > 0)
                {
                    enumerators.Add(track.GetEnumerator());
                }
            }

            playing = true;
            clock.Ppqn = mMidiFile.Quarternote;
            clock.Continue();

        }

        public void Stop()
        {
            if (!playing)
            {
                return;
            }


            playing = false;
            clock.Stop();
        }


        public void Dispose()
        {
            #region Guard

            if (disposed)
            {
                return;
            }

            #endregion


            disposed = true;

        }

        protected virtual void OnPlayingCompleted(EventArgs e)
        {
            EventHandler handler = PlayingCompleted;

            if (handler != null)
            {
                handler(this, e);
            }

            currentEvent = null;
        }

        protected virtual void OnNoteOn(Channel c, Pitch p,int v)
        {
            Action<Channel, Pitch,int> handler = NoteOn;

            if (handler != null)
            {
                handler(c,p,v);
            }
        }

        protected virtual void OnNoteOff(Channel c, Pitch p, int v)
        {
            Action<Channel, Pitch, int> handler = NoteOff;

            if (handler != null)
            {
                handler(c, p, v);
            }
        }

        protected virtual void OnProgramChange(Channel c, Instrument i)
        {
            Action<Channel, Instrument> handler = ProgramChange;

            if (handler != null)
            {
                handler(c, i);
            }
        }

        protected virtual void OnControlChange(Channel c, MidiControl m,int v)
        {
            Action<Channel, MidiControl,int> handler = ControlChange;

            if (handler != null)
            {
                handler(c, m,v);
            }
        }
        
    }
}
