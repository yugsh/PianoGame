using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;
using System.Collections.ObjectModel;

namespace PianoTest
{
    class Program
    {


        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Test Midi devices, please select:");
            Console.WriteLine("1.Input Devices");
            Console.WriteLine("2.Onput Devices");
            String select = Console.ReadLine();
            int s = Convert.ToInt32(select);
            if (s == 1)
            {
                program.InputDeviceTest();
            }
            else if(s == 2)
            {
                program.OutDeviceTest();
            }
            Console.ReadLine();
        }


        public  void OutDeviceTest()
        {
            ReadOnlyCollection<OutputDevice> devices = OutputDevice.InstalledDevices;
            if (devices.Count == 0)
            {
                Console.WriteLine("No out put devices");
                return;
            }

            foreach (OutputDevice device in devices)
            {
                Console.WriteLine("  OutputDevices Name:", device.Name);
            }

            MidiFile midiFile = new MidiFile("E:/173940.mid");
            MidiOptions options = new MidiOptions(midiFile);

            MidiPlayer player = new MidiPlayer(midiFile, options);
            player.OutDevice = devices[0];
            player.Start();
        }

        public void InputDeviceTest()
        {
            ReadOnlyCollection<InputDevice> devices = InputDevice.InstalledDevices;
            if (devices.Count == 0)
            {
                Console.WriteLine("No  input devices");
                return;
            }

            ReadOnlyCollection<OutputDevice> outDevices = OutputDevice.InstalledDevices;
            if (outDevices.Count == 0)
            {
                Console.WriteLine("No out put devices");
                return;
            }

            OutputDevice outDevice = outDevices[0];


            foreach (InputDevice device in devices)
            {
                if (!device.IsOpen)
                {
                    device.Open();
                }

                device.NoteOn += delegate(NoteOnMessage msg)
                {
                    outDevice.SendNoteOn(msg.Channel, msg.Pitch, msg.Velocity);
                };

                device.NoteOff += delegate(NoteOffMessage msg)
                {
                    outDevice.SendNoteOff(msg.Channel, msg.Pitch, msg.Velocity);
                };

                device.ProgramChange += delegate(ProgramChangeMessage msg)
                {
                    outDevice.SendProgramChange(msg.Channel, msg.Instrument);
                };

                device.PitchBend += delegate(PitchBendMessage msg)
                {
                    outDevice.SendPitchBend(msg.Channel, msg.Value);
                };
            }
        }


    }
}
