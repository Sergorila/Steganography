using System;

namespace Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            string cpath = @"C:\Users\sidorovsa\source\repos\Steganographia\Steganographia\container.txt";
            string spath = @"C:\Users\sidorovsa\source\repos\Steganographia\Steganographia\stegocontainer.txt";
            Writer w = new Writer("a", cpath, spath);
            w.Coding();
        }
    }
}
