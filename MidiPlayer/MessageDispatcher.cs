using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midi
{
    public class MessageDispatcher
    {

        public event EventHandler<MidiEvent> ChannelMessageDispatched;

        public event EventHandler<MidiEvent> SysExMessageDispatched;

        public event EventHandler<MidiEvent> SysCommonMessageDispatched;

        public event EventHandler<MidiEvent> SysRealtimeMessageDispatched;

        public event EventHandler<MidiEvent> MetaMessageDispatched;

        public MessageDispatcher()
        {
        }


        public void Dispatch(MidiEvent message)
        {
            #region Require

            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            #endregion

            switch (message.Type)
            {
                case MessageType.Channel:
                    OnChannelMessageDispatched(message);
                    break;

                case MessageType.SystemExclusive:
                    OnSysExMessageDispatched(message);
                    break;

                case MessageType.Meta:
                    OnMetaMessageDispatched(message);
                    break;

                case MessageType.SystemCommon:
                    OnSysCommonMessageDispatched(message);
                    break;

                case MessageType.SystemRealtime:

                    break;
            }
        }


        public void Chase(MidiEvent ev)
        {
            switch (ev.EventFlag)
            {
                case MidiFile.EventControlChange:
                case MidiFile.EventProgramChange:
                case MidiFile.EventChannelPressure:
                case MidiFile.EventPitchBend:
                    OnChannelMessageDispatched(ev);
                    break;
            }
        }

        protected virtual void OnChannelMessageDispatched(MidiEvent e)
        {
            EventHandler<MidiEvent> handler = ChannelMessageDispatched;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSysExMessageDispatched(MidiEvent e)
        {
            EventHandler<MidiEvent> handler = SysExMessageDispatched;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSysCommonMessageDispatched(MidiEvent e)
        {
            EventHandler<MidiEvent> handler = SysCommonMessageDispatched;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSysRealtimeMessageDispatched(MidiEvent e)
        {
            EventHandler<MidiEvent> handler = SysRealtimeMessageDispatched;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMetaMessageDispatched(MidiEvent e)
        {
            EventHandler<MidiEvent> handler = MetaMessageDispatched;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
