using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioSteganography
{
  class Program
  {
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool Beep(uint dwFreq, uint dwDuration);

    static void Main()
    {
      string password = "password";
      byte[] bytes = new byte[password.Length];

      bytes = Encoding.ASCII.GetBytes(password);


      FileStream f = new FileStream("test.wav", FileMode.Create);
      BinaryWriter wr = new BinaryWriter(f);

      uint numsamples = 44100;
      ushort numchannels = 1;
      ushort samplelength = 1; // in bytes
      uint samplerate = 22050;

      //Write the header of the wav file
      wr.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
      wr.Write(441038); //+ numsamples * numchannels * samplelength);
      wr.Write(System.Text.Encoding.ASCII.GetBytes("WAVEfmt "));
      wr.Write(16);
      wr.Write((ushort)1);
      wr.Write(numchannels);
      wr.Write(44100);
      wr.Write(88200);
      wr.Write(1048578);
      //wr.Write((ushort)(34904));
      wr.Write(1635017060);
      wr.Write(441002);

      foreach(byte b in bytes)
      {
        for(int i=0; i < 88200; i++)
        {
          wr.Write(b);
        }
      }

      wr.Close();
      f.Close();
      /*uint numsamples = 44100;
      ushort numchannels = 1;
      ushort samplelength = 1; // in bytes
      uint samplerate = 22050;

      FileStream f = new FileStream("a.wav", FileMode.Create);
      BinaryWriter wr = new BinaryWriter(f);

      wr.Write("RIFF");
      wr.Write(36 + numsamples * numchannels * samplelength);
      wr.Write("WAVEfmt ");
      wr.Write(16);
      wr.Write((ushort)1);
      wr.Write(numchannels);
      wr.Write(samplerate);
      wr.Write(samplerate * samplelength * numchannels);
      wr.Write(samplelength * numchannels);
      wr.Write((ushort)(8 * samplelength));
      wr.Write("data");
      wr.Write(numsamples * samplelength);*/

      Beep(200, 5000);
      Console.ReadLine();
    }
  }
}
