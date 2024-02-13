using System;
using System.Runtime.InteropServices;
using System.Threading;
using static MouseAndKeyboardCliker.InputSender;

namespace MouseAndKeyboardCliker
{
    public class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        public enum ScreenResolutions { QuadHD = 1, FullHD } // QuadHD (2560x1440), FullHD (1980x1080)

        public enum Modes { realization = 1, detalization }

        public static void Main()
        {
            Console.WriteLine("Разрешение экрана: ");
            Console.WriteLine("1. 2560x1440 | 2. 1980x1080 ");
            var resolution = (ScreenResolutions)Enum.Parse(typeof(ScreenResolutions), Console.ReadLine());

            Console.WriteLine("Режим работы: ");
            Console.WriteLine("1. Реализация |  2. Детализация за неделю ");
            var mode = (Modes)Enum.Parse(typeof(Modes), Console.ReadLine());

            Console.WriteLine("\nУкажите количество записей: ");
            int amountOfRecords = int.Parse(Console.ReadLine());        

            var resMode = ResolutionModeFactory.Create(resolution, mode);

            var ClickerAlg = AlgFactory.Create(resMode, mode);

            ClickerAlg.RunAlg(resMode, amountOfRecords);         
        }
    }
}
