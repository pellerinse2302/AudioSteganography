using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioSteganography
{
  class Program
  {
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool Beep(uint dwFreq, uint dwDuration);

    static void Main()
    {
      //Beep(15000, 5000);
      SoundPlayer player = new SoundPlayer(Path.Combine("D:/beep.wav"));
      player.PlayLooping();
      Console.ReadLine();
    }
  }
}
