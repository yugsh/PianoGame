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
                Console.WriteLine("  OutputDevices Name:"+ device.Name);
            }

            MidiFile midiFile = new MidiFile("E:/173940.mid");
            MidiOptions options = new MidiOptions(midiFile);

            MidiPlayer player = new MidiPlayer(midiFile, options);
            foreach (OutputDevice device in devices)
            {
                if (device.IsMidiPort)
                {
                    player.OutDevice = device;
                }
            }
            if (player.OutDevice == null)
            {
                player.OutDevice = devices[0];
            }
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

            OutputDevice outDevice = outDevices[1];
            if (outDevice != null && !outDevice.IsOpen)
            {
                outDevice.Open();
            }


            foreach (InputDevice device in devices)
            {
                if (!device.IsOpen)
                {
                    device.Open();
                    device.StartReceiving(new Clock(10));
                }

                device.NoteOn += delegate(NoteOnMessage msg)
                {
                    Console.WriteLine("NoteOnMessage => Pitch :"+msg.Pitch+"clock:"+msg.Time);
                    outDevice.SendNoteOn(msg.Channel, msg.Pitch, msg.Velocity);
                };

                device.NoteOff += delegate(NoteOffMessage msg)
                {
                    Console.WriteLine("NoteOffMessage => Pitch :" + msg.Pitch);
                    outDevice.SendNoteOff(msg.Channel, msg.Pitch, msg.Velocity);
                };

                device.ProgramChange += delegate(ProgramChangeMessage msg)
                {
                    Console.WriteLine("ProgramChangeMessage => Ins :" + msg.Instrument);
                    outDevice.SendProgramChange(msg.Channel, msg.Instrument);
                };

                device.PitchBend += delegate(PitchBendMessage msg)
                {
                    Console.WriteLine("PitchBendMessage => Pitch :" + msg.Value);
                    outDevice.SendPitchBend(msg.Channel, msg.Value);
                };
            }
        }


    }
}
