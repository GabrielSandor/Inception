using System;

namespace Inception
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new DreamDevice(int.Parse(args[1]));
            device.ExperienceDream(args[0]);

            Console.WriteLine(device.DreamStats);
        }
    }
}
