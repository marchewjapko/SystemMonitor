﻿using DataSource;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CounterTester
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var systemMonitor = new SystemMonitor();
        //    while (true)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(systemMonitor.GetSystemUsage().ToString());
        //        Console.WriteLine("Press any key to continue...");
        //        Console.ReadKey();
        //    }
        //}
        static HardwareMonitor hardwareMonitor = new HardwareMonitor();
        static void Main(string[] args)
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(hardwareMonitor.GetSystemUsage().ToString());
        }
    }
}